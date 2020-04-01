using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.Admin.Reports
{
    public class UpsertModel : PageModel
    {

        private readonly IUnitOfWork _unitofWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitofWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitofWork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }

        //binds the model to the page
        [BindProperty]
        public Report ReportObj { get; set; }
        [BindProperty]
        public IEnumerable<LaborHours> LaborHoursObj { get; set; }
        [BindProperty]
        public IEnumerable<EquipmentHours> EquipmentHoursObj { get; set; }
        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {
            if (id != null) //edit
            {
                ReportObj = _unitofWork.ReportItem.GetFirstOrDefault(u => u.Id == id);
                LaborHoursObj = _unitofWork.LaborHoursItem.GetAll();
                LaborHoursObj = LaborHoursObj.Where(u => u.ReportId == id);

                EquipmentHoursObj = _unitofWork.EquipmentHoursItem.GetAll();
                EquipmentHoursObj = EquipmentHoursObj.Where(u => u.ReportId == id);
                if (ReportObj == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                ReportObj.ApplicationUserId = claim.Value;

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                if (ReportObj.Id == 0)
                {
                    foreach(var item in LaborHoursObj)
                    {
                        _unitofWork.LaborHoursItem.Update(item);
                    }
                    foreach (var item in EquipmentHoursObj)
                    {
                        _unitofWork.EquipmentHoursItem.Update(item);
                    }
                    _unitofWork.ReportItem.Update(ReportObj);
                }
                else
                {
                    foreach (var item in LaborHoursObj)
                    {
                        _unitofWork.LaborHoursItem.Add(item);
                    }
                    foreach (var item in EquipmentHoursObj)
                    {
                        _unitofWork.EquipmentHoursItem.Add(item);
                    }
                    _unitofWork.ReportItem.Add(ReportObj);
                }
            }
            _unitofWork.Save();
            return RedirectToPage("./Index");
        }
    }
}