using WarehouseManagementSystem.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Entities.Permissions
{
    public class ReleasePermission
    {
        public ReleasePermission()
        {
            // Initialize permission type to Release
            Permission = new Permission()
            {
                Type = PermissionType.Release
            };
        }

        [Key]
        [ForeignKey(nameof(Permission))]
        [MaxLength(30)]
        public string? PermissionNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }

        // Navigation properties
        public virtual BusinessPartner? Customer { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
