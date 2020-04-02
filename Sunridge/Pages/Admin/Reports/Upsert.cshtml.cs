using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;
using Sunridge.Models.ViewModels;

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
        public ReportVM ReportVMObj { get; set; }

        [BindProperty]
        public LaborHours LaborHoursObj { get; set; }

        [BindProperty]
        public EquipmentHours EquipmentHoursObj { get; set; }

        public int laborCount = 0;
        public int equipmentCount = 0;
        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {
            ReportVMObj = new ReportVM()
            {
                Report = new Report(),
                EquipmentHours = new List<EquipmentHours>(),
                LaborHours = new List<LaborHours>()
            };
            LaborHoursObj = new LaborHours();
            EquipmentHoursObj = new EquipmentHours();

            IEnumerable<LaborHours> laborTemp = _unitofWork.LaborHoursItem.GetAll().Where(u => u.ReportId == id);
            IEnumerable<EquipmentHours> equipmentTemp = _unitofWork.EquipmentHoursItem.GetAll().Where(u => u.ReportId == id);

            if (id != null) //edit
            {
                ReportVMObj.Report = _unitofWork.ReportItem.GetFirstOrDefault(u => u.Id == id);
                ReportVMObj.EquipmentHours = equipmentTemp.ToList();
                equipmentCount = ReportVMObj.EquipmentHours.Count();
                ReportVMObj.LaborHours = laborTemp.ToList();
                laborCount = ReportVMObj.LaborHours.Count();

                if (ReportVMObj == null)
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
                ReportVMObj.Report.ApplicationUserId = claim.Value;
                ReportVMObj.Report.ApplicationUser = _unitofWork.ApplicationUser.GetFirstOrDefault(u=> u.Id == claim.Value);
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            IEnumerable<Report> tempReportIdList = _unitofWork.ReportItem.GetAll();
            int reportNum = 0;
            foreach (var item in tempReportIdList)
            {
                if(item.Id > reportNum)
                {
                    reportNum = item.Id;
                }
            }

            reportNum = reportNum + 1;

            LaborHoursObj.ReportId = reportNum;
            EquipmentHoursObj.ReportId = reportNum;

            LaborHoursObj.Report = ReportVMObj.Report;
            EquipmentHoursObj.Report = ReportVMObj.Report;

            ReportVMObj.LaborHours = new List<LaborHours>();
            ReportVMObj.EquipmentHours = new List<EquipmentHours>();

            ReportVMObj.LaborHours.Add(LaborHoursObj);
            ReportVMObj.EquipmentHours.Add(EquipmentHoursObj);
            if (ReportVMObj.Report.Id == 0) //new menu item
            {
                if(ReportVMObj.Report.Resolved == true)
                {
                    ReportVMObj.Report.ResolvedDate = DateTime.Today.ToString();
                }
                else
                {
                    ReportVMObj.Report.ResolvedDate = "Unresolved";
                }
                _unitofWork.ReportItem.Add(ReportVMObj.Report);
                foreach(var item in ReportVMObj.LaborHours)
                {
                    _unitofWork.LaborHoursItem.Add(item);
                }
                foreach (var item in ReportVMObj.EquipmentHours)
                {
                    _unitofWork.EquipmentHoursItem.Add(item);
                }
            }
            else //else we edit
            {
                if (ReportVMObj.Report.Resolved == true)
                {
                    ReportVMObj.Report.ResolvedDate = DateTime.Today.ToString();
                }
                else
                {
                    ReportVMObj.Report.ResolvedDate = "Unresolved";
                }
                _unitofWork.ReportItem.Update(ReportVMObj.Report);
                foreach (var item in ReportVMObj.LaborHours)
                {
                    _unitofWork.LaborHoursItem.Update(item);
                }
                foreach (var item in ReportVMObj.EquipmentHours)
                {
                    _unitofWork.EquipmentHoursItem.Update(item);
                }
            }

            _unitofWork.Save();
            return RedirectToPage("./Index");
        }
    }
}