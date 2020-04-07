using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class ClassifiedListing
    {
        public int ClassifiedListingId { get; set; }

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

        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ClassifiedCategoryId { get; set; }
        public string Category { get; set; }
        [Required]
        [ForeignKey("ClassifiedCategoryId")]
        public ClassifiedCategory Categories { get; set; }

        public string Images { get; set; }
        public List<ClassifiedImage> Image { get; set; }
    }
}
