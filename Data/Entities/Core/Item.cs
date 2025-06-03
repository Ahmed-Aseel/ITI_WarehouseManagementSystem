using WarehouseManagementSystem.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Entities.Permissions;

namespace WarehouseManagementSystem.Data.Entities.Core
{
    public class Item
    {
        public Item()
        {
            Inventories = new HashSet<InventoryItem>();
            PermissionItems = new HashSet<PermissionItem>();
        }

        [Key]
        [MaxLength(30)]
        public string? ItemCode { get; set; }

        [Required]
        [MaxLength(30)]
        public string? ItemName { get; set; }

        [Required]
        [MaxLength(25)]
        public string? UnitOfMeasurement { get; set; }

        // Navigation Properties
        public virtual ICollection<InventoryItem> Inventories { get; set; }
        public virtual ICollection<PermissionItem> PermissionItems { get; set; }
    }
}
