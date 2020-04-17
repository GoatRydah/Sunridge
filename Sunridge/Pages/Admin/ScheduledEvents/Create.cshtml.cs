using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;

namespace Sunridge.Pages.Admin.ScheduledEvents
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CreateModel(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }

        //binds the model to the page
        [BindProperty]
        public Models.ScheduledEvent ScheduledEventObj { get; set; }
        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {

            ScheduledEventObj = new Models.ScheduledEvent();
            if (id != null) //edit
            {
                ScheduledEventObj = _unitofWork.ScheduledEvents.GetFirstOrDefault(u => u.ID == id);

                if (ScheduledEventObj == null)
                {
                    return NotFound();
                }
            }
            else
            {
                ScheduledEventObj = new Models.ScheduledEvent();

            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ScheduledEventObj.ID == 0) //new category
            {
                _unitofWork.ScheduledEvents.Add(ScheduledEventObj);
            }
            else
            {
                _unitofWork.ScheduledEvents.Update(ScheduledEventObj);
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {

                //find root path wwwroot
                string webRootPath = _hostingEnvironment.WebRootPath;
                //Grab the file(s) from the form
                var files = HttpContext.Request.Form.Files;

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (ScheduledEventObj.ID == 0) //new 
                {
                    //rename file user submits for image
                    string fileName = Guid.NewGuid().ToString();
                    //upload file to the path
                    var uploads = Path.Combine(webRootPath, @"images\ScheduledEvents");
                    //preserve our extension
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream); //files variable comes from the razor page files id
                    }

                    ScheduledEventObj.Image = @"\images\ScheduledEvents\" + fileName + extension;

                    _unitofWork.ScheduledEvents.Add(ScheduledEventObj);
                }
                else //else we edit
                {
                    var objFromDb =
                        _unitofWork.ScheduledEvents.Get(ScheduledEventObj.ID);
                    //checks if there are files submitted
                    if (files.Count > 0)
                    {
                        //rename file user submits for image
                        string fileName = Guid.NewGuid().ToString();
                        //upload file to the path
                        var uploads = Path.Combine(webRootPath, @"images\ScheduledEvents");
                        //preserve our extension
                        var extension = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var filestream = new FileStream(Path.Combine(uploads, fileName, extension), FileMode.Create))
                        {
                            files[0].CopyTo(filestream);
                        }

                        ScheduledEventObj.Image = @"\images\ScheduledEvents\" + fileName + extension;
                    }
                    else
                    {
                        ScheduledEventObj.Image = objFromDb.Image;
                    }

                    _unitofWork.ScheduledEvents.Update(ScheduledEventObj);
                }
            }
            _unitofWork.Save();
            return RedirectToPage("./Index");
        }
    }
}