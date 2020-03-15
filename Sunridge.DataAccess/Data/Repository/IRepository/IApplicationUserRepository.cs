using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Models;
using System.Collections.Generic;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        IEnumerable<SelectListItem> GetApplicationUserListOrDropdown();

        void Update(ApplicationUser applicationUser);
    }
}
