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

namespace Sunridge.Pages.Admin.KeysHistory
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
        public KeyHistoryViewModel KeyHistoryObj { get; set; }

        public IActionResult OnGet(int? id)  //id is optional
        {
            //populate the lists for dropdowns
            KeyHistoryObj = new KeyHistoryViewModel()
            {
                Key = _unitOfWork.Key.GetCategoryListOrDropdown(),
                Lot = _unitOfWork.Lot.GetLotListOrDropdown(),
                KeyHistory = new Models.KeyHistory()
            };



            if (id != null) //edit
            {
                KeyHistoryObj.KeyHistory = _unitOfWork.KeyHistory.GetFirstOrDefault(u => u.KeyHistoryId == id);
                if (KeyHistoryObj == null)
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
            if (KeyHistoryObj.KeyHistory.KeyHistoryId == 0) //new Food Type
            {
                _unitOfWork.KeyHistory.Add(KeyHistoryObj.KeyHistory);
            }
            else //update the Food Type (edit)
            {
                _unitOfWork.KeyHistory.Update(KeyHistoryObj.KeyHistory);
            }

            //commit changes to the db
            _unitOfWork.Save();

            return RedirectToPage("./Index");
        }
    }
}