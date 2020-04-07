using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.Admin.HOALots
{
    public class FilesIndexModel : PageModel
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        //binds the model to the page
        [BindProperty]
        public Lot LotObj { get; set; }

        public FilesIndexModel(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnGet(int id)
        {
            var temp = TempData["AnId"];
            int theId = 0;

            if (id == 0)
            {
                theId = Int32.Parse(temp.ToString());
                LotObj = _unitofWork.Lot.GetFirstOrDefault(s => s.LotId == theId);
                TempData["lotId"] = LotObj.LotId;
            }
            else
            {
                LotObj = _unitofWork.Lot.GetFirstOrDefault(s => s.LotId == id);
            }
        }
    }
}