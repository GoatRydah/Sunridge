using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Models;
using System.Collections.Generic;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IClassifiedCategoryRepository : IRepository<ClassifiedCategory>
    {
        IEnumerable<SelectListItem> GetClassifiedCategoryListOrDropdown();

        void Update(ClassifiedCategory classifiedCategory);
    }
}
