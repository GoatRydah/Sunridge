using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sunridge.Models.ViewModels
{
    public class ClassifiedListingVM
    {
        public ClassifiedListing ClassifiedListing { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }
    }
}
