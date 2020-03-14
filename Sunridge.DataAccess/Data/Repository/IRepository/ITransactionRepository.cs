using Microsoft.AspNetCore.Mvc.Rendering;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface ITransactionRepository : IRepository<SunridgeHOA.Models.Transaction>
    {
        IEnumerable<SelectListItem> GetTransactionListOrDropdown();

        void Update(SunridgeHOA.Models.Transaction transaction);
    }
}
