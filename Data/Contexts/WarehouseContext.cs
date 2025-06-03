using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Entities.Core;
using WarehouseManagementSystem.Data.Entities.Inventory;
using WarehouseManagementSystem.Data.Entities.Permissions;

namespace WarehouseManagementSystem.Data.Contexts
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext() { }

        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options) { }

        // DbSets for each entity
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<SupplyPermission> SupplyPermissions { get; set; }
        public DbSet<ReleasePermission> ReleasePermissions { get; set; }
        public DbSet<TransferPermission> TransferPermissions { get; set; }
        public DbSet<PermissionItem> PermissionItems { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASEEL\\SQLEXPRESS;Initial Catalog=WarehouseManagementSystem;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table Mappings and Constraints
            modelBuilder.Entity<Warehouse>().ToTable("Warehouses");
            modelBuilder.Entity<Item>().ToTable("Items");

            modelBuilder.Entity<InventoryItem>().ToTable("InventoryItems", table =>
            {
                table.HasCheckConstraint("CK_Inventory_ExpiryDate", "[ExpiryDate] > [ProductionDate]");
                table.HasCheckConstraint("CK_InventoryRecord_Quantity", "[Quantity] >= 0");
            });
            modelBuilder.Entity<InventoryItem>()
                .HasKey(ir => new { ir.WarehouseID, ir.ItemCode, ir.ProductionDate });

            modelBuilder.Entity<BusinessPartner>().ToTable("BusinessPartners", table =>
            {
                table.HasCheckConstraint(
                    "CK_BusinessPartner_Type",
                    $"[Type] IN ({(byte)PartnerType.Supplier}, {(byte)PartnerType.Customer})"
                );
            });

            modelBuilder.Entity<Permission>().ToTable("Permissions", table =>
            {
                table.HasCheckConstraint(
                    "CK_Permission_Type",
                    $"[Type] IN ({(byte)PermissionType.Supply}, {(byte)PermissionType.Release}, {(byte)PermissionType.Transfer})"
                );
            });

            modelBuilder.Entity<SupplyPermission>().ToTable("SupplyPermissions");
            modelBuilder.Entity<ReleasePermission>().ToTable("ReleasePermissions");

            modelBuilder.Entity<TransferPermission>().ToTable("TransferPermissions");

            modelBuilder.Entity<PermissionItem>().ToTable("PermissionItems", table =>
            {
                table.HasCheckConstraint("CK_PermissionItem_Quantity", "[Quantity] > 0");
            });
            #endregion

            #region Relationships
            // Warehouse ↔ InventoryRecord (one-to-many)
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.Inventories)
                .WithOne(ir => ir.Warehouse)
                .HasForeignKey(ir => ir.WarehouseID)
                .OnDelete(DeleteBehavior.Cascade);

            // Item ↔ InventoryRecord (one-to-many)
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Inventories)
                .WithOne(ir => ir.Item)
                .HasForeignKey(ir => ir.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);

            // BusinessPartner ↔ SupplyPermissions (one-to-many)
            modelBuilder.Entity<BusinessPartner>()
                .HasMany(bp => bp.SupplyPermissions)
                .WithOne(sp => sp.Supplier)
                .HasForeignKey(sp => sp.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);

            // BusinessPartner ↔ ReleasePermissions (one-to-many)
            modelBuilder.Entity<BusinessPartner>()
                .HasMany(bp => bp.ReleasePermissions)
                .WithOne(dp => dp.Customer)
                .HasForeignKey(dp => dp.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            // Warehouse (Main Warehouse) ↔ Permission (one-to-many)
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.Permissions)
                .WithOne(p => p.MainWarehouse)
                .HasForeignKey(p => p.MainWarehouseID)
                .OnDelete(DeleteBehavior.Restrict);

            // Warehouse (Destination Warehouse) ↔ TransferPermission (one-to-many)
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.Transfers)
                .WithOne(tp => tp.DestWarehouse)
                .HasForeignKey(tp => tp.DestWarehouseID)
                .OnDelete(DeleteBehavior.Restrict);

            // SupplyPermission ↔ Permission (One-to-One)
            modelBuilder.Entity<SupplyPermission>()
                .HasOne(sp => sp.Permission)
                .WithOne(p => p.SupplyPermission)
                .HasForeignKey<SupplyPermission>(sp => sp.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // ReleasePermission ↔ Permission (One-to-One)
            modelBuilder.Entity<ReleasePermission>()
                .HasOne(dp => dp.Permission)
                .WithOne(p => p.ReleasePermission)
                .HasForeignKey<ReleasePermission>(dp => dp.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // TransferPermission ↔ Permission (One-to-One)
            modelBuilder.Entity<TransferPermission>()
                .HasOne(tp => tp.Permission)
                .WithOne(p => p.TransferPermission)
                .HasForeignKey<TransferPermission>(tp => tp.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // Permission ↔PermissionItem (one-to-many)
            modelBuilder.Entity<Permission>()
                .HasMany(p => p.PermissionItems)
                .WithOne(pi => pi.Permission)
                .HasForeignKey(pi => pi.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // Item ↔ PermissionItem (one-to-many)
            modelBuilder.Entity<Item>()
                .HasMany(i => i.PermissionItems)
                .WithOne(pi => pi.Item)
                .HasForeignKey(pi => pi.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
