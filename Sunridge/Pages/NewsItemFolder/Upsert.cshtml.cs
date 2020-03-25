﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.NewsItemFolder
{
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
        public Models.NewsItem NewsItemObj { get; set; }
        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {
            //NewsItem = new NewsItem();

            if (id != null) //edit
            {
                NewsItemObj = _unitofWork.NewsItem.GetFirstOrDefault(u => u.NewsItemId == id);
                if (NewsItemObj == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            //    //find root path wwwroot
            //    string webRootPath = _hostingEnvironment.WebRootPath;
            //    //Grab the file(s) from the form
            //    var files = HttpContext.Request.Form.Files;

            //    //if (!ModelState.IsValid)
            //    //{
            //    //    return Page();
            //    //}

            //    if (NewsItemObj.NewsItemId == 0) //new lostandfounditem
            //    {
            //        //rename file user submits for image
            //        string fileName = Guid.NewGuid().ToString();
            //        //upload file to the path
            //        var uploads = Path.Combine(webRootPath, @"docs\NewItemFiles");
            //        //preserve our extension
            //        var extension = Path.GetExtension(files[0].FileName);

            //        using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            //        {
            //            files[0].CopyTo(filestream); //files variable comes from the razor page files id
            //        }

            //        NewsItemObj.FilePath = @"\docs\NewItemFiles\" + fileName + extension;

            //        _unitofWork.NewsItem.Add(NewsItemObj);
            //    }
            //    else //else we edit
            //    {
            //        var objFromDb =
            //            _unitofWork.NewsItem.Get(NewsItemObj.NewsItemId);
            //        //checks if there are files submitted
            //        if (files.Count > 0)
            //        {
            //            //rename file user submits for image
            //            string fileName = Guid.NewGuid().ToString();
            //            //upload file to the path
            //            var uploads = Path.Combine(webRootPath, @"docs\NewItemFiles");
            //            //preserve our extension
            //            var extension = Path.GetExtension(files[0].FileName);

            //            var imagePath = Path.Combine(webRootPath, objFromDb.FilePath.TrimStart('\\'));

            //            if (System.IO.File.Exists(imagePath))
            //            {
            //                System.IO.File.Delete(imagePath);
            //            }

            //            using (var filestream = new FileStream(Path.Combine(uploads, fileName, extension), FileMode.Create))
            //            {
            //                files[0].CopyTo(filestream);
            //            }

            //            NewsItemObj.FilePath = @"\docs\NewsItemFiles\" + fileName + extension;
            //        }
            //        else
            //        {
            //            NewsItemObj.FilePath = objFromDb.FilePath;
            //        }
            //        _unitofWork.NewsItem.Update(NewsItemObj);
            //    }
            //    _unitofWork.Save();
            //    return RedirectToPage("./Index");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NewsItemObj.NewsItemId == 0) //new category
            {
                _unitofWork.NewsItem.Add(NewsItemObj);
            }
            else //else we edit
            {
                _unitofWork.NewsItem.Update(NewsItemObj);
            }
            _unitofWork.Save();
            return RedirectToPage("./Index");
        }
    }
}