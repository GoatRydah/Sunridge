using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sunridge.Models
{
    public class CommonAreaAsset : DbItem
    {
        public int CommonAreaAssetId { get; set; }
        [Display(Name = "Asset Name")]
        public string AssetName { get; set; }
        [Display(Name = "Purchase Price")]
        public float PurchasePrice { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public int MaintenancesId { get; set; }

        // Nav properties
        [ForeignKey("MaintenanceId")]
        public ICollection<Maintenance> Maintenances { get; set; }


    }
}
