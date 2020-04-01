using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sunridge.DataAccess.Data.Repository
{
    public class ClassifiedListingVMRepository : Repository<ClassifiedListingVM>, IClassifiedListingVMRepository
    {
        private readonly ApplicationDbContext _db;

        public ClassifiedListingVMRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetClassifiedListingVMListOrDropdown()
        {
            return _db.ClassifiedListingVM.Select(i => new SelectListItem()
            {
                Value = i.Category.ToString(),
                Text = i.ClassifiedListing.ToString()
            });
        }

        public void Update(ClassifiedListingVM address)
        {
            var objFromDb = _db.ClassifiedListingVM.FirstOrDefault(s => s.ClassifiedListing == address.ClassifiedListing);
            objFromDb.Category = address.Category;

            _db.SaveChanges();
        }
    }
}
