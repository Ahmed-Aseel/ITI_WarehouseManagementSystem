using WarehouseManagementSystem.Data.Entities.Core;
using WarehouseManagementSystem.Data.Entities.Permissions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Entities.Transfers
{
    public class Transfer
    {
        public Transfer()
        {
            TransferPermissions = new HashSet<TransferPermission>();
        }

        [Key]
        [MaxLength(30)]
        public string? TransferNumber { get; set; }

        [Required]
        public DateTime? TransferDate { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey("SourceWh")]
        public int SrcWhID { get; set; }

        [Required]
        [ForeignKey("DestinationWh")]
        public int DestWhID { get; set; }

        // Navigation properties
        public virtual Warehouse? SourceWh { get; set; }
        public virtual Warehouse? DestinationWh { get; set; }
        public virtual ICollection<TransferPermission> TransferPermissions { get; set; }
    }
}
