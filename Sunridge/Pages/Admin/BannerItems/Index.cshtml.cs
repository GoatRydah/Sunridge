﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;

namespace Sunridge.Pages.Admin.BannerItems
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Banner> BannerList { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            BannerList = _unitOfWork.Banner.GetAll();
        }
    }
}