using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class OwnerLot : DbItem
    {
        public int OwnerLotId { get; set; }
        public int OwnerId { get; set; }
        public int LotId { get; set; }

        public bool IsPrimary { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Nav properties
        [ForeignKey("OwnerId")]
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("LotId")]
        public Lot Lot { get; set; }

    }
}
