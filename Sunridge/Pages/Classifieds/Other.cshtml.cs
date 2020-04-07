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
    public class OtherModel : PageModel
    {
        public readonly IUnitOfWork _unitOfWork;

        public OtherModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public List<string> serviceUrls { get; set; }

        public void OnGet()
        {

        }
    }
}