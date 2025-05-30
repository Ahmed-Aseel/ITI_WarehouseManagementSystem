using WarehouseManagementSystem.Data.Entities.Core;
using WarehouseManagementSystem.Data.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Entities.Transfers
{
    public class PermissionItem
    {
        [MaxLength(30)]
        [ForeignKey("Permission")]
        public string? PermissionNumber { get; set; }

        [MaxLength(30)]
        [ForeignKey("Item")]
        public string? ItemCode { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        // Navigation properties
        public virtual Permission? Permission { get; set; }
        public virtual Item? Item { get; set; }
    }
}
