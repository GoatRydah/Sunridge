using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class LostAndFoundItem
    {
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}