using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;
using Sunridge.Models.ViewModels;
using Sunridge.Utility;

namespace Sunridge.Pages.Admin.Classifieds
{
    [Authorize(Roles = SD.AdminRole)]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }

        //binds the model to the page
        [BindProperty]
        public ClassifiedListing ClassifiedObj { get; set; }

        public IActionResult OnGet(int? id)  //id is optional
        {
            //populate the lists for dropdowns
            ClassifiedObj = new ClassifiedListing();

            if (id != null) //edit
            {
                ClassifiedObj = _unitofWork.ClassifiedListing.GetFirstOrDefault(u => u.ClassifiedListingId == id);
                if (ClassifiedObj == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            //find root path to wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;
            //grab the file(s) from the form
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }


            //new menu item
            if (ClassifiedObj.ClassifiedListingId == 0)
            {
                //rename the file the user submits
                //guid is a unique string that will not be duplicated
                string fileName = Guid.NewGuid().ToString();

                //upload to path
                var uploads = Path.Combine(webRootPath, @"images\classifieds");

                //preserve our extension
                var extension = Path.GetExtension(files[0].FileName);

                //append new name to the extension
                using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                ClassifiedObj.Image = @"\images\classifieds\" + fileName + extension;

                //add it to the db
                _unitofWork.ClassifiedListing.Add(ClassifiedObj);
            }
            //edit the menu item 
            else
            {
                var objFromDb = _unitofWork.ClassifiedListing.Get(ClassifiedObj.ClassifiedListingId);
                //were there any files
                if (files.Count > 0)
                {
                    //rename the file the user submits
                    //guid is a unique string that will not be duplicated
                    string fileName = Guid.NewGuid().ToString();

                    //upload to path
                    var uploads = Path.Combine(webRootPath, @"images\banner");

                    //preserve our extension
                    var extension = Path.GetExtension(files[0].FileName);
                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    //if image already exists
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    //append new name to the extension
                    using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }

                    ClassifiedObj.Image = @"\images\clssifieds\" + fileName + extension;
                }
                else
                {
                    ClassifiedObj.Image = objFromDb.Image;
                }
                _unitofWork.ClassifiedListing.Update(ClassifiedObj);
            }
            _unitofWork.Save();
            return RedirectToPage("./Index");
            }
        }
}