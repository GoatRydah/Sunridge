using Microsoft.AspNetCore.Mvc.Rendering;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface ILotHistoryRepository : IRepository<LotHistory>
    {
        IEnumerable<SelectListItem> GetLotHistoryListOrDropdown();

        void Update(LotHistory lotHistory);
    }
}
