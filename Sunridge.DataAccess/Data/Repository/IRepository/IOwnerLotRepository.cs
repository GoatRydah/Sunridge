using Microsoft.AspNetCore.Mvc.Rendering;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IOwnerLotRepository : IRepository<OwnerLot>
    {
        IEnumerable<SelectListItem> GetOwnerLotListOrDropdown();

        void Update(OwnerLot ownerLot);
    }
}
