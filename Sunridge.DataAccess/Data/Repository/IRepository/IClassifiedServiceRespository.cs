using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Models;
using System.Collections.Generic;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IClassifiedServiceRepository : IRepository<ClassifiedService>
    {
        IEnumerable<SelectListItem> GetClassifiedServiceListOrDropdown();

        void Update(ClassifiedService classifiedService);
    }
}
