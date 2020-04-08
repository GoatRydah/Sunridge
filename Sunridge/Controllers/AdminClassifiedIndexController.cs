using System;
using System.IO;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Sunridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminClassifiedIndexController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminClassifiedIndexController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.ClassifiedListing.GetAll(null, null, null) });
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var objFromDb = _unitOfWork.ClassifiedListing.GetFirstOrDefault(u => u.ClassifiedListingId == id);
        //        if (objFromDb == null)
        //        {
        //            return Json(new { success = false, message = "Error while deleting" });
        //        }
        //        Physically Delete the image in wwwroot
        //        var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.Images.TrimStart('\\'));
        //        if (System.IO.File.Exists(imagePath))
        //        {
        //            System.IO.File.Delete(imagePath);
        //        }

        //        _unitOfWork.ClassifiedListing.Remove(objFromDb);
        //        _unitOfWork.Save();
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    return Json(new { success = true, message = "Delete Successful" });

        //}
    }
}