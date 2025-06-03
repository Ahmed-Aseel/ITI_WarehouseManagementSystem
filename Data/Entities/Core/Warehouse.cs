using WarehouseManagementSystem.Data.Entities.Inventory;
using WarehouseManagementSystem.Data.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Entities.Core
{
    public class Warehouse
    {
        public Warehouse()
        {
            Inventories = new HashSet<InventoryItem>();
            Permissions = new HashSet<Permission>();
            Transfers = new HashSet<TransferPermission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseID { get; set; }

        [Required]
        [MaxLength(30)]
        public string? WarehouseName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Location { get; set; }

        [Required]
        [MaxLength(30)]
        public string? ManagerName { get; set; }

        // Navigation Properties
        public virtual ICollection<InventoryItem> Inventories { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<TransferPermission> Transfers { get; set; }
    }
}
