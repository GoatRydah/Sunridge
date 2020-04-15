using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.Admin.ScheduledEvents
{
    public class CreateModel : PageModel
    {
        private readonly Sunridge.Data.ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public CreateModel(Sunridge.Data.ApplicationDbContext context, IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ScheduledEvent ScheduledEvent { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ScheduledEvent.Add(ScheduledEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //    public IActionResult OnPost()
        //{
        //    //find root path to wwwroot
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    //grab the file(s) from the form
        //    var files = HttpContext.Request.Form.Files;

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }


        //    //new menu item
        //    if (ScheduledEvent.ID == 0)
        //    {
        //        //rename the file the user submits
        //        //guid is a unique string that will not be duplicated
        //        string fileName = Guid.NewGuid().ToString();

        //        //upload to path
        //        var uploads = Path.Combine(webRootPath, @"images\ScheduledEvents");

        //        //preserve our extension
        //        var extension = Path.GetExtension(files[0].FileName);

        //        //append new name to the extension
        //        using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
        //        {
        //            files[0].CopyTo(filestream);
        //        }

        //        ScheduledEvent.Image = @"\images\ScheduledEvents\" + fileName + extension;

        //        //add it to the db
        //        _unitOfWork.ScheduledEvents.Add(ScheduledEvent);
        //    }
        //    //edit the menu item 
        //    else
        //    {
        //        var objFromDb = _unitOfWork.ScheduledEvents.Get(ScheduledEvent.ID);
        //        //were there any files
        //        if (files.Count > 0)
        //        {
        //            //rename the file the user submits
        //            //guid is a unique string that will not be duplicated
        //            string fileName = Guid.NewGuid().ToString();

        //            //upload to path
        //            var uploads = Path.Combine(webRootPath, @"images\ScheduledEvents");

        //            //preserve our extension
        //            var extension = Path.GetExtension(files[0].FileName);
        //            var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

        //            //if image already exists
        //            if (System.IO.File.Exists(imagePath))
        //            {
        //                System.IO.File.Delete(imagePath);
        //            }

        //            //append new name to the extension
        //            using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
        //            {
        //                files[0].CopyTo(filestream);
        //            }

        //            ScheduledEvent.Image = @"\images\ScheduledEvents\" + fileName + extension;
        //        }
        //        else
        //        {
        //            ScheduledEvent.Image = objFromDb.Image;
        //        }

        //        _unitOfWork.ScheduledEvents.Update(ScheduledEvent);
        //    }

        //    //commit changes to the db
        //    _unitOfWork.Save();

        //    return RedirectToPage("./Index");
        //}
    }
}
