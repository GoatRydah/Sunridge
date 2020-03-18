using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class ClassifiedListing : DbItem
    {
        public int ClassifiedListingId { get; set; }
        public string OwnerId { get; set; }
        public int ClassifiedCategoryId { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(75, MinimumLength = 5)]
        public string ItemName { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public float Price { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 25)]
        public string Description { get; set; }

        [Display(Name = "Listing Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ListingDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagesId { get; set; }

        //Nav properties
        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }
        [ForeignKey("ClassifiedCategoryId")]
        public ClassifiedCategory ClassifiedCategory { get; set; }
        [ForeignKey("ImagesId")]
        public List<ClassifiedImage> Images { get; set; }
    }
}
