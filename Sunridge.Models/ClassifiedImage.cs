using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class ClassifiedImage
    {
        public int ClassifiedImageId { get; set; }
        public int ClassifiedListingId { get; set; }

        public bool IsMainImage { get; set; }
        public string ImageURL { get; set; }
        public string ImageExtension { get; set; }
        [ForeignKey("ClassifiedListingId")]
        public ClassifiedListing ClassifiedListing { get; set; }
    }
}
