using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class LaborHours
    {
        public int Id { get; set; }

        [Display(Name = "Labor Activity")]
        public List<String> LaborActivity { get; set; }
        public List<String> Hours { get; set; }
    }
}