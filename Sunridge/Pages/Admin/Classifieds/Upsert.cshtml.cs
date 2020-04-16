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
        public ClassifiedListingVM ClassifiedObj { get; set; }

        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {
            //LostAndFoundItem = new LostAndFoundItem();

            if (id != null) //edit
            {
                ClassifiedObj = new ClassifiedListingVM();
                ClassifiedObj.ClassifiedListing = _unitofWork.ClassifiedListing.GetFirstOrDefault(u => u.ClassifiedListingId == id);
                ClassifiedObj.CategoryList = _unitofWork.ClassifiedCategory.GetClassifiedCategoryListOrDropdown();

                if (ClassifiedObj == null)
                {
                    return NotFound();
                }
            }
            else
            {
                ClassifiedObj = new ClassifiedListingVM();
                ClassifiedObj.ClassifiedListing = new ClassifiedListing();
                ClassifiedObj.CategoryList = _unitofWork.ClassifiedCategory.GetClassifiedCategoryListOrDropdown();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            int catNum = Int32.Parse(ClassifiedObj.ClassifiedListing.Categories);
            ClassifiedObj.ClassifiedListing.Category = _unitofWork.ClassifiedCategory.GetFirstOrDefault(u => u.ClassifiedCategoryId == catNum);
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _unitofWork.ApplicationUser.GetFirstOrDefault(s => s.Id == userId);
           // ClassifiedObj.ClassifiedListing. = user.FirstName + " " + user.LastName;

            //find root path wwwroot
            string webRootPath = _hostingEnvironment.WebRootPath;
            //Grab the file(s) from the form
            var files = HttpContext.Request.Form.Files;

            if (ClassifiedObj.ClassifiedListing.ClassifiedListingId == 0) //new photo object
            {
                //rename file user submits for image
                string fileName = Guid.NewGuid().ToString();
                //upload file to the path
                var uploads = Path.Combine(webRootPath, @"images\classifieds\");
                //preserve our extension
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream); //files variable comes from the razor page files id
                }

                ClassifiedObj.ClassifiedListing.Image = @"\images\classifieds\" + fileName + extension;

                _unitofWork.ClassifiedListing.Add(ClassifiedObj.ClassifiedListing);
            }
            else //else we edit
            {
                var objFromDb =
                    _unitofWork.ClassifiedListing.Get(ClassifiedObj.ClassifiedListing.ClassifiedListingId);
                //checks if there are files submitted
                if (files.Count > 0)
                {
                    //rename file user submits for image
                    string fileName = Guid.NewGuid().ToString();
                    //upload file to the path
                    var uploads = Path.Combine(webRootPath, @"images\classifieds");
                    //preserve our extension
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var filestream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }

                    ClassifiedObj.ClassifiedListing.Image = @"\images\classifieds\" + fileName + extension;
                }
                else
                {
                    ClassifiedObj.ClassifiedListing.Image = objFromDb.Image;
                }
                _unitofWork.ClassifiedListing.Update(ClassifiedObj.ClassifiedListing);
            }
            _unitofWork.Save();
            return RedirectToPage("./Index");
        }
    }
}