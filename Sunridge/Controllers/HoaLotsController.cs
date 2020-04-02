using System;
using System.IO;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sunridge.Utility;
using System.Security.Claims;
using Sunridge.Models.ViewModels;
using System.Collections.Generic;

namespace Sunridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaLotsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public List<HOALotVM> HoaLots { get; set; }

        public HoaLotsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            HoaLots = new List<HOALotVM>();

            var theLots = _unitOfWork.Lot.GetAll(null, null, null);
            HOALotVM tempModel = new HOALotVM();

            foreach(var lot in theLots)
            {
                // set lotnumber and taxid
                tempModel.LotNumber = lot.LotNumber;
                tempModel.TaxId = lot.TaxId;

                //set address value
                var address = _unitOfWork.Address.GetFirstOrDefault(s => s.Id == lot.AddressId);
                string addr = $"{address.StreetAddress} {address.Apartment} {address.City}, {address.State} {address.Zip}";
                tempModel.StreetAddress = addr;

                //get owner(s) for lot
                string theOwners = "";
                var ownerLots = _unitOfWork.OwnerLot.GetAll(s => s.LotId == lot.LotId);
                //add owner(s) to string
                foreach(var oLot in ownerLots)
                {
                    var owner = _unitOfWork.ApplicationUser.GetFirstOrDefault(s => s.Id == oLot.OwnerId);

                    //TODO: if owner is primary, bold them and put them first, else don't
                    theOwners += owner.FullName + ", ";
                }

                //trim last comma
                if (theOwners.Length > 1)
                    theOwners = theOwners.Substring(0, theOwners.Length - 2);

                //add owner(s) to model
                tempModel.UserName = theOwners;

                //TODO: get and set lot inventory data

                HoaLots.Add(tempModel);
            }


            return Json(new { data = _unitOfWork.Lot.GetAll(null, null, null) });
        }
    }
}