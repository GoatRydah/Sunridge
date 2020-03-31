using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.Admin.Owners
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //binds the model to the page
        [BindProperty]
        public ApplicationUser OwnerObj { get; set; }
        [BindProperty]
        public Address AddressObj { get; set; }

        public UpsertModel(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet(string id)
        {

            //string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            OwnerObj = new ApplicationUser();
            if (id != null)
                OwnerObj = _unitofWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);
            AddressObj = new Address();
            if (id != null)
                AddressObj = _unitofWork.Address.GetFirstOrDefault(u => u.Id == OwnerObj.AddressId);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (AddressObj.Id != 0)
                OwnerObj.AddressId = AddressObj.Id;

            var user = _unitofWork.ApplicationUser.GetFirstOrDefault(s => s.Id == OwnerObj.Id);

            if (user == null)
            {
                _unitofWork.Address.Add(AddressObj);
                OwnerObj.AddressId = AddressObj.Id;
                OwnerObj.Address = AddressObj;
                OwnerObj.UserName = OwnerObj.FirstName + OwnerObj.LastName;
                _unitofWork.ApplicationUser.Add(OwnerObj);
                _unitofWork.Save();
            }
            else
            {
                _unitofWork.ApplicationUser.Update(OwnerObj);
                _unitofWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}