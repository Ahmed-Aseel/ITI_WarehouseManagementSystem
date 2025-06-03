using WarehouseManagementSystem.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Entities.Permissions
{
    public class SupplyPermission
    {
        public SupplyPermission()
        {
            // Initialize permission type to Supply
            Permission = new Permission
            {
                Type = PermissionType.Supply
            };
        }

        [Key]
        [ForeignKey(nameof(Permission))]
        [MaxLength(30)]
        public string? PermissionNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Supplier))]
        public int SupplierID { get; set; }

        // Navigation properties
        public virtual BusinessPartner? Supplier { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
