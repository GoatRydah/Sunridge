using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models.ViewModels
{
    public class AdminPhotoViewModels
    {
        public int AdminPhotoViewModelsId { get; set; }
        public Photo Photo { get; set; }
        public IEnumerable<Owner> Owner { get; set; }
    }
}
