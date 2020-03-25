﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;

namespace Sunridge.Pages.Classifieds
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
    public Classifieds ClassifiedsObj { get; set; }
    public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
    {
        //LostAndFoundItem = new LostAndFoundItem();

        if (id != null) //edit
        {
                ClassifiedsObj = _unitofWork.LostAndFoundItem.GetFirstOrDefault(u => u.Id == id);
            if (ClassifiedsObj == null)
            {
                return NotFound();
            }
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        //find root path wwwroot
        string webRootPath = _hostingEnvironment.WebRootPath;
        //Grab the file(s) from the form
        var files = HttpContext.Request.Form.Files;

        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (LostAndFoundItemObj.Id == 0) //new lostandfounditem
        {
            //rename file user submits for image
            string fileName = Guid.NewGuid().ToString();
            //upload file to the path
            var uploads = Path.Combine(webRootPath, @"images\lostAndFoundItems");
            //preserve our extension
            var extension = Path.GetExtension(files[0].FileName);

            using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                files[0].CopyTo(filestream); //files variable comes from the razor page files id
            }

            LostAndFoundItemObj.Image = @"\images\lostAndFoundItems\" + fileName + extension;

            _unitofWork.LostAndFoundItem.Add(LostAndFoundItemObj);
        }
        else //else we edit
        {
            var objFromDb =
                _unitofWork.LostAndFoundItem.Get(LostAndFoundItemObj.Id);
            //checks if there are files submitted
            if (files.Count > 0)
            {
                //rename file user submits for image
                string fileName = Guid.NewGuid().ToString();
                //upload file to the path
                var uploads = Path.Combine(webRootPath, @"images\lostAndFoundItems");
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

                LostAndFoundItemObj.Image = @"\images\lostAndFoundItem\" + fileName + extension;
            }
            else
            {
                LostAndFoundItemObj.Image = objFromDb.Image;
            }
            _unitofWork.LostAndFoundItem.Update(LostAndFoundItemObj);
        }
        _unitofWork.Save();
        return RedirectToPage("./Index");
    }
}
}