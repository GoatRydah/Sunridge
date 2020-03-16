using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Models;
using System.Collections.Generic;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IClassifiedListingRepository : IRepository<ClassifiedListing>
    {
        IEnumerable<SelectListItem> GetClassifiedListingListOrDropdown();

        void Update(ClassifiedListing applicationUser);
    }
}
