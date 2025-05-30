using WarehouseManagementSystem.Data.Entities.Inventory;
using WarehouseManagementSystem.Data.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Entities.Transfers;

namespace WarehouseManagementSystem.Data.Entities.Core
{
    public class Warehouse
    {
        public Warehouse()
        {
            Inventories = new HashSet<InventoryItem>();
            Permissions = new HashSet<Permission>();
            OutgoingTransfers = new HashSet<Transfer>();
            IncomingTransfers = new HashSet<Transfer>();
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
        public virtual ICollection<Transfer> OutgoingTransfers { get; set; }
        public virtual ICollection<Transfer> IncomingTransfers { get; set; }
    }
}
