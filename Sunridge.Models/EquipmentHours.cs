using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class EquipmentHours
    {
        public int Id { get; set; }

        [Display(Name = "Equipment")]
        public List<String> EquipmentName { get; set; }
        public List<String> Hours { get; set; }
    }
}