using WarehouseManagementSystem.Data.Entities.Core;
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
        Release,
        Transfer
    }

    [Index(nameof(PermissionDate))] // Fix for CS0592 and CS0618
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
        [Column(TypeName = "date")]
        public DateTime? PermissionDate { get; set; } = DateTime.Today.Date;

        [Required]
        public PermissionType Type { get; set; }

        [Required]
        [ForeignKey(nameof(MainWarehouse))]
        public int MainWarehouseID { get; set; } // For Supply/Release/Transfer (Source)

        // Navigation properties
        public virtual Warehouse? MainWarehouse { get; set; }
        public virtual SupplyPermission? SupplyPermission { get; set; }
        public virtual ReleasePermission? ReleasePermission { get; set; }
        public virtual TransferPermission? TransferPermission { get; set; }
        public virtual ICollection<PermissionItem> PermissionItems { get; set; }
    }
}
