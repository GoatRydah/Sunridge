﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sunridge.Models
{
    public class BoardMember
    {
        public int Id { get; set; }

        public string BoardRole { get; set; }
        public string Image { get; set; }

        //keep track of who the user is
        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        
        [Display(Name = "Lot Name")]
        public int LotId { get; set; }
        [ForeignKey("LotId")]
        public Lot Lot { get; set; }
    }
}