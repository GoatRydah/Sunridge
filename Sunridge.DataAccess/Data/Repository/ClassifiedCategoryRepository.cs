using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sunridge.DataAccess.Data.Repository
{
    public class ClassifiedCategoryRepository : Repository<ClassifiedCategory>, IClassifiedCategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public ClassifiedCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetClassifiedCategoryListOrDropdown()
        {
            return _db.ClassifiedCategory.Select(i => new SelectListItem()
            {
                Value = i.ClassifiedCategoryId.ToString(),
                Text = i.CategoryName.ToString()
            });
        }

        public void Update(ClassifiedCategory classifiedCategory)
        {
            var objFromDb = _db.ClassifiedCategory.FirstOrDefault(s => s.ClassifiedCategoryId == classifiedCategory.ClassifiedCategoryId);
            objFromDb.CategoryName = classifiedCategory.CategoryName;

            _db.SaveChanges();
        }
    }
}
