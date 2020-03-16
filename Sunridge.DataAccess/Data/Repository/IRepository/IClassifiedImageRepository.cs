using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Models;
using System.Collections.Generic;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IClassifiedImageRepository : IRepository<ClassifiedImage>
    {
        IEnumerable<SelectListItem> GetClassifiedImageListOrDropdown();

        void Update(ClassifiedImage classifiedImage);
    }
}
