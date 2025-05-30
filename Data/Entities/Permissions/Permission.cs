using WarehouseManagementSystem.Data.Entities.Core;
using WarehouseManagementSystem.Data.Entities.Transfers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementSystem.Data.Entities.Permissions
{
    public enum PermissionType : byte
    {
        Supply,
        Dispense,
        Transfer
    }

    [Index(nameof(PermissionDate), IsUnique = true)] // Fix for CS0592 and CS0618
    public class Permission
    {
        public Permission()
        {
            PermissionItems = new HashSet<PermissionItem>();
        }

        [Key]
        [MaxLength(30)]
        public string? PermissionNumber { get; set; }

        [Required]
        public DateTime? PermissionDate { get; set; } = DateTime.Now;

        [Required]
        public PermissionType Type { get; set; }

        [Required]
        [ForeignKey("Warehouse")]
        public int WarehouseID { get; set; }

        // Navigation properties
        public virtual Warehouse? Warehouse { get; set; }
        public virtual SupplyPermission? SupplyPermission { get; set; }
        public virtual ReleasePermission? ReleasePermission { get; set; }
        public virtual TransferPermission? TransferPermission { get; set; }
        public virtual ICollection<PermissionItem> PermissionItems { get; set; }
    }
}
