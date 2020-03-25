using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Data;
using Sunridge.DataAccess.Data.Repository.IRepository;
using Sunridge.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sunridge.DataAccess.Data.Repository
{
    public class ClassifiedListingViewModelRepository : Repository<ClassifiedListingViewModel>, IClassifiedListingViewModelRepository
    {
        private readonly ApplicationDbContext _db;

        public ClassifiedListingViewModelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetClassifiedListingViewModelListOrDropdown()
        {
            return _db.ClassifiedListingViewModel.Select(i => new SelectListItem()
            {
                Value = i.ClassifiedCategory.ToString(),
                Text = i.ClassifiedListing.ToString()
            });
        }

        public void Update(ClassifiedListingViewModel address)
        {
            var objFromDb = _db.ClassifiedListingViewModel.FirstOrDefault(s => s.ClassifiedListing == address.ClassifiedListing);
            objFromDb.ClassifiedCategory = address.ClassifiedCategory;
            objFromDb.Owner = address.Owner;

            _db.SaveChanges();
        }
    }
}
