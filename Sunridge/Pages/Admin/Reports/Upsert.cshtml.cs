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

        public IActionResult OnGet(int? id) ///IActionResult return type is page, obj
        {
            ReportVMObj = new ReportVM()
            {
                Report = new Report(),
                EquipmentHours = new List<EquipmentHours>(),
                LaborHours = new List<LaborHours>()
            };


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

        public void OnPostLaborPlus()
        {
            LaborHours temp = new LaborHours();
            temp.ReportId = 0;
            if(ReportVMObj.LaborHours == null)
            {
                ReportVMObj.LaborHours = new List<LaborHours>();
            }
            if (ReportVMObj.EquipmentHours == null)
            {
                ReportVMObj.EquipmentHours = new List<EquipmentHours>();
            }
            ReportVMObj.LaborHours.Add(temp);
        }

        public void OnPostEquipmentPlus()
        {
            EquipmentHours temp = new EquipmentHours();
            temp.ReportId = 0;
            if (ReportVMObj.LaborHours == null)
            {
                ReportVMObj.LaborHours = new List<LaborHours>();
            }
            if (ReportVMObj.EquipmentHours == null)
            {
                ReportVMObj.EquipmentHours = new List<EquipmentHours>();
            }
            ReportVMObj.EquipmentHours.Add(temp);
        }

        public IActionResult OnPostCreate()
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
                //equipment and labor

                if (ReportVMObj.Report.Resolved == true)
                {
                    ReportVMObj.Report.ResolvedDate = DateTime.Today.ToString();
                }
                else
                {
                    ReportVMObj.Report.ResolvedDate = "Unresolved";
                }
                _unitofWork.ReportItem.Add(ReportVMObj.Report); //inserts report
                _unitofWork.Save();
                IEnumerable<Report> tempReportIdList = _unitofWork.ReportItem.GetAll(); //goes to db and grabs all reports
                int reportNum = 0;
                foreach (var item in tempReportIdList) //loops through the narrow down the last inserted report
                {
                    if (item.Id > reportNum)
                    {
                        reportNum = item.Id;
                    }
                }
                if (ReportVMObj.LaborHours != null)
                {
                    for (int i = 0; i < ReportVMObj.LaborHours.Count(); i++)
                    {
                        ReportVMObj.LaborHours[i].ReportId = reportNum;
                        ReportVMObj.LaborHours[i].Report = ReportVMObj.Report;
                    }
                    foreach (var item in ReportVMObj.LaborHours)
                    {
                        _unitofWork.LaborHoursItem.Add(item);
                    }
                }
                if (ReportVMObj.EquipmentHours != null)
                {
                    for (int i = 0; i < ReportVMObj.EquipmentHours.Count(); i++)
                    {
                        ReportVMObj.EquipmentHours[i].ReportId = reportNum;
                        ReportVMObj.EquipmentHours[i].Report = ReportVMObj.Report;
                    }
                    foreach (var item in ReportVMObj.EquipmentHours)
                    {
                        _unitofWork.EquipmentHoursItem.Add(item);
                    }
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

                try
                {

                    for (int i = 0; i < ReportVMObj.LaborHours.Count; i++)
                    {
                        ReportVMObj.LaborHours[i].ReportId = ReportVMObj.Report.Id;
                        ReportVMObj.LaborHours[i].Report = ReportVMObj.Report;
                        _unitofWork.LaborHoursItem.Update(ReportVMObj.LaborHours[i]);
                    }
                    for (int i = 0; i < ReportVMObj.EquipmentHours.Count; i++)
                    {
                        ReportVMObj.EquipmentHours[i].ReportId = ReportVMObj.Report.Id;
                        ReportVMObj.EquipmentHours[i].Report = ReportVMObj.Report;
                        _unitofWork.EquipmentHoursItem.Update(ReportVMObj.EquipmentHours[i]);
                    }
                }catch(Exception e)
                {
                    ReportVMObj.Report.ApplicationUser = _unitofWork.ApplicationUser.GetFirstOrDefault(u => u.Id == ReportVMObj.Report.ApplicationUserId);
                    ReportVMObj.Report.username = ReportVMObj.Report.ApplicationUser.FullName;
                    _unitofWork.Save();
                    return RedirectToPage("./Index");
                }
            }
            ReportVMObj.Report.ApplicationUser = _unitofWork.ApplicationUser.GetFirstOrDefault(u => u.Id == ReportVMObj.Report.ApplicationUserId);
            ReportVMObj.Report.username = ReportVMObj.Report.ApplicationUser.FullName;
            _unitofWork.Save();
            return RedirectToPage("./Index");
        }
    }
}