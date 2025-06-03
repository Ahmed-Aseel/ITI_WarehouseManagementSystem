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
    public class PermissionItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermItemID { get; set; }

        [Required]
        [MaxLength(30)]
        [ForeignKey(nameof(Permission))]
        public string? PermissionNumber { get; set; }

        [Required]
        [MaxLength(30)]
        [ForeignKey(nameof(Item))]
        public string? ItemCode { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; } = DateTime.Today.Date;

        [Required]
        [Range(1, int.MaxValue)]
        public int ExpiryDuration { get; set; } // In days

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        // Navigation properties
        public virtual Permission? Permission { get; set; }
        public virtual Item? Item { get; set; }
    }
}
