using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Models;
using System.Collections.Generic;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IDbItemRepository : IRepository<DbItem>
    {
        IEnumerable<SelectListItem> GetDbItemListOrDropdown();

        void Update(DbItem address);
    }
}
