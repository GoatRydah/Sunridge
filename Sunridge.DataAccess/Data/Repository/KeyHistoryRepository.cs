using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using SunridgeHOA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sunridge.DataAccess.Data.Repository
{
    public class KeyHistoryRepository : Repository<KeyHistory>, IKeyHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public KeyHistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetKeyHistoryListOrDropdown()
        {
            return _db.KeyHistory.Select(i => new SelectListItem()
            {
                Text = i.KeyHistoryId.ToString(),
                Value = i.KeyId.ToString()
            });
        }

        public void Update(KeyHistory keyHistory)
        {
            throw new NotImplementedException();
        }
    }
}
