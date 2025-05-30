using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Data.Entities.Transfers;

namespace WarehouseManagementSystem.Data.Entities.Permissions
{
    public enum TransferDirection : byte
    {
        Outgoing,
        Incoming
    }

    public class TransferPermission
    {
        [Key]
        [ForeignKey("Permission")]
        [MaxLength(30)]
        public string? PermissionNumber { get; set; }

        [Required]
        public TransferDirection Direction { get; set; }

        [Required]
        [ForeignKey("Transfer")]
        [MaxLength(30)]
        public string? TransferNumber { get; set; }

        // Navigation properties
        public virtual Transfer? Transfer { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}
