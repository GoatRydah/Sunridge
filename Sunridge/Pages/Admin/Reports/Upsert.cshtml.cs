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
        public List<LaborHours> laborHoursList { get; set; }

        [BindProperty]
        public List<EquipmentHours> equipmentHoursList { get; set; }

        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {
            ReportVMObj = new ReportVM()
            {
                Report = new Report(),
                EquipmentHours = new List<EquipmentHours>(),
                LaborHours = new List<LaborHours>()
            };

            laborHoursList = new List<LaborHours>();
            equipmentHoursList = new List<EquipmentHours>();

            for (int i = 0; i < 10; i++)
            {
                LaborHours temp = new LaborHours();
                laborHoursList.Add(temp);
                EquipmentHours etemp = new EquipmentHours();
                equipmentHoursList.Add(etemp);
            }


            if (id != null) //edit
            {
                IEnumerable<LaborHours> laborTemp = _unitofWork.LaborHoursItem.GetAll().Where(u => u.ReportId == id);
                IEnumerable<EquipmentHours> equipmentTemp = _unitofWork.EquipmentHoursItem.GetAll().Where(u => u.ReportId == id);

                ReportVMObj.Report = _unitofWork.ReportItem.GetFirstOrDefault(u => u.Id == id);
                ReportVMObj.EquipmentHours = equipmentTemp.ToList();
                //equipmentCount = ReportVMObj.EquipmentHours.Count();
                ReportVMObj.LaborHours = laborTemp.ToList();
                //laborCount = ReportVMObj.LaborHours.Count();

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

           
            
            if (ReportVMObj.Report.Id == 0) //new  item
            {
                for (int i = 9; i >= 0; i--)
                {
                    if(laborHoursList[i].LaborActivity ==null|| laborHoursList[i].Hours==null)
                    {
                        laborHoursList.Remove(laborHoursList[i]);
                    }
                }
                for (int i = 9; i >= 0; i--)
                {
                    if (equipmentHoursList[i].EquipmentName == null || equipmentHoursList[i].Hours == null)
                    {
                        equipmentHoursList.Remove(equipmentHoursList[i]);
                    }
                }
                ReportVMObj.LaborHours = laborHoursList;
                ReportVMObj.EquipmentHours = equipmentHoursList;
                IEnumerable<Report> tempReportIdList = _unitofWork.ReportItem.GetAll();
                int reportNum = 0;
                foreach (var item in tempReportIdList)
                {
                    if (item.Id > reportNum)
                    {
                        reportNum = item.Id;
                    }
                }

                reportNum = reportNum + 1;

                for (int i = 0; i < ReportVMObj.LaborHours.Count(); i++)
                {
                    ReportVMObj.LaborHours[i].ReportId = reportNum;
                    ReportVMObj.LaborHours[i].Report = ReportVMObj.Report;
                }

                for (int i = 0; i < ReportVMObj.EquipmentHours.Count(); i++)
                {
                    ReportVMObj.EquipmentHours[i].ReportId = reportNum;
                    ReportVMObj.EquipmentHours[i].Report = ReportVMObj.Report;
                }

                if (ReportVMObj.Report.Resolved == true)
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