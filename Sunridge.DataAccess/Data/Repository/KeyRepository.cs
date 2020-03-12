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
    public class KeyRepository : Repository<Key>, IKeyRepository
    {
        private readonly ApplicationDbContext _db;

        public KeyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListOrDropdown()
        {
            return _db.Key.Select(i => new SelectListItem()
            {
                Text = i.SerialNumber,
                Value = i.Year.ToString()
            });
        }

        public void Update(Key key)
        {
            var objFromDb = _db.Key.FirstOrDefault(s => s.SerialNumber == key.SerialNumber);

            objFromDb.SerialNumber = key.SerialNumber;
            objFromDb.Year = key.Year;

            _db.SaveChanges();
        }
    }
}
