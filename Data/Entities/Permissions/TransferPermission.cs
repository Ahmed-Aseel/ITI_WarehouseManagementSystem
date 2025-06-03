using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Entities.Core;

namespace WarehouseManagementSystem.Data.Entities.Permissions
{
    public class TransferPermission
    {
        public TransferPermission()
        {
            // Initialize the permission type to Transfer
            Permission = new Permission()
            {
                Type = PermissionType.Transfer
            };
        }

        [Key]
        [ForeignKey(nameof(Permission))]
        [MaxLength(30)]
        public string? PermissionNumber { get; set; }

        [Required]
        [ForeignKey(nameof(DestWarehouse))]
        public int DestWarehouseID { get; set; } // For Transfer (Destination)

        // Navigation properties
        public virtual Warehouse? DestWarehouse { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
