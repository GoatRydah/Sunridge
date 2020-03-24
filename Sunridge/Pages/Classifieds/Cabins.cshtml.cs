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
    public class CabinsModel : PageModel
    {
        public readonly IUnitOfWork _unitOfWork;

        public CabinsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ClassifiedListing> ClassifiedListingsList { get; set; }

        public void OnGet()
        {
            ClassifiedListingsList = _unitOfWork.ClassifiedListing.GetAll();
        }
    }
}