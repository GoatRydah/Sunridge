﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        IEnumerable<SelectListItem> GetPhotoListOrDropdown();

        void Update(Photo photo);
    }
}
