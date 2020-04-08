﻿using System;
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
        public ClassifiedListing ClassifiedsObj { get; set; }
        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {
            //if (id != null) //edit
            //{
            //    ClassifiedsObj = new ClassifiedListing();
            //    ClassifiedsObj.ClassifiedListing = _unitofWork.ClassifiedListing.GetFirstOrDefault(u => u.ClassifiedListingId == id);
            //    ClassifiedsObj.Category = _unitofWork.ClassifiedCategory.GetClassifiedCategoryListOrDropdown();

            //    if (ClassifiedsObj == null)
            //    {
            //        return NotFound();
            //    }
            //}
            //else
            //{
            //    ClassifiedsObj = new ClassifiedListingVM();
            //    ClassifiedsObj.ClassifiedListing = new ClassifiedListing();
            //    ClassifiedsObj.Category = _unitofWork.ClassifiedCategory.GetClassifiedCategoryListOrDropdown();
            //}

            return Page();
        }

        public IActionResult OnPost()
        {
            //find root path wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;
            //Grab the file(s) from the form
            var files = HttpContext.Request.Form.Files;

            //string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = _unitofWork.ApplicationUser.GetFirstOrDefault(s => s.Id == userId);
            //ClassifiedsObj.ClassifiedListing.Owner = user.FirstName + " " + user.LastName;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //if (ClassifiedsObj.ClassifiedListingId == 0) //new classified object
            //{
            //    rename file user submits for image
            //    string fileName = Guid.NewGuid().ToString();
            //    upload file to the path
            //    var uploads = Path.Combine(webRootPath, @"images\classifieds");
            //    preserve our extension
            //    var extension = Path.GetExtension(files[0].FileName);

            //    using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            //    {
            //        files[0].CopyTo(filestream); //files variable comes from the razor page files id
            //    }

            //    ClassifiedsObj.ClassifiedListing.Images = @"\images\classifieds\" + fileName + extension;

            //    _unitofWork.ClassifiedListing.Add(ClassifiedsObj.ClassifiedListing);
            //}
            //else //else we edit
            //{
            //    var objFromDb =
            //        _unitofWork.ClassifiedListing.Get(ClassifiedsObj.ClassifiedListing.ClassifiedListingId);
            //    checks if there are files submitted
            //    if (files.Count > 0)
            //    {
            //        rename file user submits for image
            //        string fileName = Guid.NewGuid().ToString();
            //        upload file to the path
            //        var uploads = Path.Combine(webRootPath, @"images\classifieds");
            //        preserve our extension
            //        var extension = Path.GetExtension(files[0].FileName);

            //        var imagePath = Path.Combine(webRootPath, objFromDb.Images.TrimStart('\\'));

            //        if (System.IO.File.Exists(imagePath))
            //        {
            //            System.IO.File.Delete(imagePath);
            //        }

            //        using (var filestream = new FileStream(Path.Combine(uploads, fileName, extension), FileMode.Create))
            //        {
            //            files[0].CopyTo(filestream);
            //        }

            //        ClassifiedsObj.ClassifiedListing.Images = @"\images\classifieds\" + fileName + extension;
            //    }
            //    else
            //    {
            //        ClassifiedsObj.ClassifiedListing.Images = objFromDb.Images;
            //    }
            //    _unitofWork.ClassifiedListing.Update(ClassifiedsObj.ClassifiedListing);
            //}
            _unitofWork.Save();
            return RedirectToPage("./Index");
            }
        }
}