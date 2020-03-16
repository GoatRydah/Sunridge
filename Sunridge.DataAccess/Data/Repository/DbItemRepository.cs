using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sunridge.DataAccess.Data.Repository
{
    public class DbItemRepository : Repository<DbItem>, IDbItemRepository
    {
        private readonly ApplicationDbContext _db;

        public DbItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetDbItemListOrDropdown()
        {
            return _db.DbItem.Select(i => new SelectListItem()
            {
                Value = "",
                Text = ""
            });
        }

        public void Update(DbItem dbItem)
        {
            _db.SaveChanges();
        }
    }
}
