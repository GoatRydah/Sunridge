using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models.ViewModels
{
    //for admin
    public class ClassifiedListingViewModel
    {
        public int ClassifiedListingViewModelId { get; set; }
        public ClassifiedListing ClassifiedListing { get; set; }
        public IEnumerable<ClassifiedCategory> ClassifiedCategory { get; set; }
        public IEnumerable<ApplicationUser> Owner { get; set; }
    }

}
