using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Data.Entities.Core;
using WarehouseManagementSystem.Data.Entities.Inventory;
using WarehouseManagementSystem.Data.Entities.Permissions;
using WarehouseManagementSystem.Data.Entities.Transfers;

namespace WarehouseManagementSystem.Data.Contexts
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext()
        {
        }

        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
        }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<SupplyPermission> SupplyPermissions { get; set; }
        public DbSet<ReleasePermission> ReleasePermissions { get; set; }
        public DbSet<TransferPermission> TransferPermissions { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
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
                    $"[Type] IN ({(byte)PermissionType.Supply}, {(byte)PermissionType.Dispense}, {(byte)PermissionType.Transfer})"
                );
            });

            modelBuilder.Entity<SupplyPermission>().ToTable("SupplyPermissions");
            modelBuilder.Entity<ReleasePermission>().ToTable("ReleasePermissions");

            modelBuilder.Entity<TransferPermission>().ToTable("TransferPermissions", table =>
            {
                table.HasCheckConstraint(
                    "CK_TransferPermission_Direction",
                    $"[Direction] IN ({(byte)TransferDirection.Outgoing}, {(byte)TransferDirection.Incoming})"
                );
            });

            modelBuilder.Entity<Transfer>().ToTable("Transfers", table =>
            {
                table.HasCheckConstraint("CK_Transfer_SrcDest_Wh", "[SrcWhID] <> [DestWhID]");
            });

            modelBuilder.Entity<PermissionItem>().ToTable("PermissionItems", table =>
            {
                table.HasCheckConstraint("CK_PermissionItem_Quantity", "[Quantity] > 0");
            });
            modelBuilder.Entity<PermissionItem>()
                .HasKey(pi => new { pi.PermissionNumber, pi.ItemCode });
            #endregion

            #region Relationships
            // Warehouse ↔ InventoryRecord
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.Inventories)
                .WithOne(ir => ir.Warehouse)
                .HasForeignKey(ir => ir.WarehouseID)
                .OnDelete(DeleteBehavior.Cascade);

            // Item ↔ InventoryRecord
            modelBuilder.Entity<Item>()
                .HasMany(i => i.Inventories)
                .WithOne(ir => ir.Item)
                .HasForeignKey(ir => ir.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);

            // BusinessPartner ↔ Permissions
            modelBuilder.Entity<BusinessPartner>()
                .HasMany(bp => bp.SupplyPermissions)
                .WithOne(sp => sp.Supplier)
                .HasForeignKey(sp => sp.SupplierID)
                .OnDelete(DeleteBehavior.Restrict);

            // BusinessPartner ↔ ReleasePermissions
            modelBuilder.Entity<BusinessPartner>()
                .HasMany(bp => bp.ReleasePermissions)
                .WithOne(dp => dp.Customer)
                .HasForeignKey(dp => dp.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Permission ↔ Warehouse
            modelBuilder.Entity<Permission>()
                .HasOne(p => p.Warehouse)
                .WithMany(w => w.Permissions)
                .HasForeignKey(p => p.WarehouseID)
                .OnDelete(DeleteBehavior.Cascade);

            // Permission ↔ SupplyPermission/ReleasePermission/TransferPermission (One-to-One)
            modelBuilder.Entity<SupplyPermission>()
                .HasOne(sp => sp.Permission)
                .WithOne(p => p.SupplyPermission)
                .HasForeignKey<SupplyPermission>(sp => sp.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // ReleasePermission ↔ Permission
            modelBuilder.Entity<ReleasePermission>()
                .HasOne(dp => dp.Permission)
                .WithOne(p => p.ReleasePermission)
                .HasForeignKey<ReleasePermission>(dp => dp.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // TransferPermission ↔ Permission
            modelBuilder.Entity<TransferPermission>()
                .HasOne(tp => tp.Permission)
                .WithOne(p => p.TransferPermission)
                .HasForeignKey<TransferPermission>(tp => tp.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // Transfer ↔ Warehouses
            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.SourceWh)
                .WithMany(w => w.OutgoingTransfers)
                .HasForeignKey(t => t.SrcWhID)
                .OnDelete(DeleteBehavior.Restrict);

            // Transfer ↔ Destination Warehouse
            modelBuilder.Entity<Transfer>()
                .HasOne(t => t.DestinationWh)
                .WithMany(w => w.IncomingTransfers)
                .HasForeignKey(t => t.DestWhID)
                .OnDelete(DeleteBehavior.Restrict);

            // PermissionItem ↔ Permission & Item
            modelBuilder.Entity<PermissionItem>()
                .HasOne(pi => pi.Permission)
                .WithMany(p => p.PermissionItems)
                .HasForeignKey(pi => pi.PermissionNumber)
                .OnDelete(DeleteBehavior.Cascade);

            // PermissionItem ↔ Item
            modelBuilder.Entity<PermissionItem>()
                .HasOne(pi => pi.Item)
                .WithMany(i => i.PermissionItems)
                .HasForeignKey(pi => pi.ItemCode)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
