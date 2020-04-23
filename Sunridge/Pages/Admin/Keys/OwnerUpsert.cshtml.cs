using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.Models;
using Sunridge.Models.ViewModels;
using System.Security.Claims;

namespace Sunridge.Pages.Admin.Keys
{
    public class OwnerUpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        //dependency injection
        public OwnerUpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public KeyHistory KeyHistoryObj { get; set; }

        public Key OwnerKey { get; set; }


        public IActionResult OnGet(int? id)  //id is optional
        {
            if(KeyHistoryObj == null)
            {
                KeyHistoryObj = new KeyHistory();
            }

            if (id != null) //edit
            {
                KeyHistoryObj = _unitOfWork.KeyHistory.GetFirstOrDefault(u => u.KeyHistoryId == id);

                OwnerKey = _unitOfWork.Key.GetFirstOrDefault(u => u.KeyId == KeyHistoryObj.KeyId);

                if (KeyHistoryObj == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            //get current user
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            KeyHistoryObj.LastModifiedBy = claim.Value;
            KeyHistoryObj.LastModifiedDate = DateTime.Now;
            _unitOfWork.KeyHistory.Update(KeyHistoryObj);


            //commit changes to the db
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}