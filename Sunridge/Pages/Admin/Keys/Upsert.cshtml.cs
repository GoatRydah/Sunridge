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

namespace Sunridge.Pages.Admin.Keys
{
    [Authorize(Roles = SD.AdminRole)]//have to be admin to access this page
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        //dependency injection
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Key KeyObj { get; set; }

        public IActionResult OnGet(int? id)  //id is optional
        {
            KeyObj = new Key();

            if (id != null) //edit
            {
                KeyObj = _unitOfWork.Key.GetFirstOrDefault(u => u.KeyId == id);
                if (KeyObj == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (KeyObj.KeyId == 0) //new Food Type
            {
                _unitOfWork.Key.Add(KeyObj);
            }
            else //update the Food Type (edit)
            {
                _unitOfWork.Key.Update(KeyObj);
            }

            //commit changes to the db
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}