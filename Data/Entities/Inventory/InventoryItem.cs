using WarehouseManagementSystem.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Entities.Inventory
{
    public class InventoryItem
    {
        [ForeignKey("Warehouse")]
        public int WarehouseID { get; set; }

        [MaxLength(30)]
        [ForeignKey("Item")]
        public string? ItemCode { get; set; }

        [Required]
        public DateTime? ProductionDate { get; set; }

        [Required]
        public DateTime? ExpiryDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        // Navigation properties
        public virtual Warehouse? Warehouse { get; set; }
        public virtual Item? Item { get; set; }
    }
}
