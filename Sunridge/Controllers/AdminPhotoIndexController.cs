using System;
using System.IO;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Sunridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPhotoIndexController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdminPhotoIndexController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Photo.GetAll(null, null, null) });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _unitOfWork.Photo.GetFirstOrDefault(u => u.PhotoId == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Error while deleting" });
                }
                //Physically Delete the image in wwwroot
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                _unitOfWork.Photo.Remove(objFromDb);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            return Json(new { success = true, message = "Delete Successful" });

        }
    }
}