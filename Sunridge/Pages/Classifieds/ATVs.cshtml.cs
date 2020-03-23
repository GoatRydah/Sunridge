using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.Classifieds
{
    public class ATVsModel : PageModel
    {

        public readonly IUnitOfWork _unitOfWork;


        public ATVsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  List<ClassifiedListing> ClassifiedListings { get; set; }

        public void OnGet()
        {
         //   ClassifiedListings = _unitOfWork.ClassifiedListing.GetAll(null, null, "ClassifiedType");

        }
    }
}