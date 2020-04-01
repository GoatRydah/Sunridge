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
        public string LaborActivity { get; set; }
        public string Hours { get; set; }
    }
}