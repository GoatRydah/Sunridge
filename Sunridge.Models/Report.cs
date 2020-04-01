using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Display(Name = "Form Type")]
        [Required]
        public Owner Owner { get; set; }
        [Display(Name= "Listing Date")]
        public string ListingDate { get; set; }
        [Display(Name = "Resolved Date")]
        public string ResolvedDate { get; set; }
        public string Description { get; set; }
        public string Suggestion { get; set; }
        public string Comments { get; set; }
        public bool Resolved { get; set; }

        public int LaborHoursId { get; set; }
        [NotMapped]
        [ForeignKey("LaborHoursId")]

        public LaborHours LaborHours { get; set; }


        public int EquipmentHoursId { get; set; }
        [NotMapped]
        [ForeignKey("EquipmentHoursId")]

        public LaborHours EquipmentHours { get; set; }
    }
}