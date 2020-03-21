using Microsoft.AspNetCore.Mvc.Rendering;
using Sunridge.Models.ViewModels;
using System.Collections.Generic;

namespace Sunridge.DataAccess.Data.Repository.IRepository
{
    public interface IClassifiedListingViewModelRepository : IRepository<ClassifiedListingViewModel>
    {
        IEnumerable<SelectListItem> GetClassifiedListingViewModelListOrDropdown();

        void Update(ClassifiedListingViewModel address);
    }
}
