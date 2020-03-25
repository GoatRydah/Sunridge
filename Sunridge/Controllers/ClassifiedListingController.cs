using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sunridge.Controllers
{
    public class ClassifiedListingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}