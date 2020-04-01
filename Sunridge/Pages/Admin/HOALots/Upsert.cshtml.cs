using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //binds the model to the page
        [BindProperty]
        public Lot LotObj { get; set; }
        [BindProperty]
        public Address AddressObj { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> Owners { get; set; }
        [BindProperty]
        public ApplicationUser PrimaryOwner { get; set; }
        [BindProperty]
        public ApplicationUser SecondaryOwner { get; set; }
        [BindProperty]
        public IEnumerable<Inventory> InventoryObj { get; set; }
        [BindProperty]
        public OwnerLot OwnerLotObj { get; set; }

        public UpsertModel(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet(int id)
        {
            LotObj = new Lot();
            LotObj = _unitofWork.Lot.GetFirstOrDefault(u => u.LotId == id);

            AddressObj = _unitofWork.Address.GetFirstOrDefault(s => s.Id == LotObj.AddressId);

            PrimaryOwner = new ApplicationUser();
            Owners = _unitofWork.ApplicationUser.GetApplicationUserListOrDropdown();

            InventoryObj = _unitofWork.Inventory.GetAll(null, null, null);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //update lot
            _unitofWork.Lot.Update(LotObj);

            //update address
            _unitofWork.Address.Update(AddressObj);

            //add/update ownerlot

            //foreach (Owner owner in OwnerObj)
            //{
            //    OwnerLotObj = new OwnerLot();
            //    OwnerLotObj.LotId = LotObj.LotId;
            //    //OwnerLotObj.OwnerId = owner.Id;
            //}

            //update lot inventory


            return Page();
        }
    }
}