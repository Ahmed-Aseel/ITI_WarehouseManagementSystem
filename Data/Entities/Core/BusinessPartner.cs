using WarehouseManagementSystem.Data.Entities.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Data.Entities.Core
{
    public enum PartnerType : byte
    {
        Supplier,
        Customer
    }

    public class BusinessPartner
    {
        public BusinessPartner()
        {
            SupplyPermissions = new HashSet<SupplyPermission>();
            ReleasePermissions = new HashSet<ReleasePermission>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartnerID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        public PartnerType Type { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(20)]
        public string? Fax { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Mobile { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? Website { get; set; }

        // Navigation Properties
        public virtual ICollection<SupplyPermission> SupplyPermissions { get; set; }
        public virtual ICollection<ReleasePermission> ReleasePermissions { get; set; }
    }
}
