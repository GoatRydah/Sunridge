using System;
using System.IO;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sunridge.Utility;
using System.Security.Claims;
using System.Collections.Generic;
using Sunridge.Models;

namespace Sunridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerIndexController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public OwnerIndexController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (User.IsInRole(SD.AdminRole))
            {                
                return Json(new { data = _unitOfWork.ApplicationUser.GetAll(s => s.IsArchive == false, null, null) });
            }
            else //(the User.IsInRole(SD.OwnerRole))
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Json(new { data = _unitOfWork.ApplicationUser.GetAll(s => s.Id == userId, null, null) });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var objFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }

                objFromDb.IsArchive = true;
                _unitOfWork.ApplicationUser.Update(objFromDb);
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            return Json(new { success = true, message = "Delete Successful" });

        }
    }
}