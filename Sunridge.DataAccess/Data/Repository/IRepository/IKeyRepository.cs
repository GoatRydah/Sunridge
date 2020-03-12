using Microsoft.AspNetCore.Mvc.Rendering;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IKeyRepository: IRepository<Key>
    {
        IEnumerable<SelectListItem> GetCategoryListOrDropdown();

        void Update(Key key);
    }
}
