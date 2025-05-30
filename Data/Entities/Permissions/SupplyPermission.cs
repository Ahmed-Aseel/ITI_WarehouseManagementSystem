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
        [Key]
        [ForeignKey("Permission")]
        [MaxLength(30)]
        public string? PermissionNumber { get; set; }

        [Required]
        public DateTime? ProductionDate { get; set; } = DateTime.Now;

        [Required]
        [Range(1, int.MaxValue)]
        public int ExpiryDuration { get; set; } // in days

        [Required]
        [ForeignKey("BusinessPartner")]
        public int SupplierID { get; set; }

        // Navigation properties
        public virtual BusinessPartner? Supplier { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
