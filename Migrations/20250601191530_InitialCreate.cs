using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessPartners",
                columns: table => new
                {
                    PartnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartners", x => x.PartnerID);
                    table.CheckConstraint("CK_BusinessPartner_Type", "[Type] IN (0, 1)");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => new { x.WarehouseID, x.ItemCode, x.ProductionDate });
                    table.CheckConstraint("CK_Inventory_ExpiryDate", "[ExpiryDate] > [ProductionDate]");
                    table.CheckConstraint("CK_InventoryRecord_Quantity", "[Quantity] >= 0");
                    table.ForeignKey(
                        name: "FK_InventoryItems_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Warehouses_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PermissionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    MainWarehouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionNumber);
                    table.CheckConstraint("CK_Permission_Type", "[Type] IN (0, 1, 2)");
                    table.ForeignKey(
                        name: "FK_Permissions_Warehouses_MainWarehouseID",
                        column: x => x.MainWarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionItems",
                columns: table => new
                {
                    PermItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDuration = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionItems", x => x.PermItemID);
                    table.CheckConstraint("CK_PermissionItem_Quantity", "[Quantity] > 0");
                    table.ForeignKey(
                        name: "FK_PermissionItems_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionItems_Permissions_PermissionNumber",
                        column: x => x.PermissionNumber,
                        principalTable: "Permissions",
                        principalColumn: "PermissionNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReleasePermissions",
                columns: table => new
                {
                    PermissionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleasePermissions", x => x.PermissionNumber);
                    table.ForeignKey(
                        name: "FK_ReleasePermissions_BusinessPartners_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "BusinessPartners",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReleasePermissions_Permissions_PermissionNumber",
                        column: x => x.PermissionNumber,
                        principalTable: "Permissions",
                        principalColumn: "PermissionNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyPermissions",
                columns: table => new
                {
                    PermissionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyPermissions", x => x.PermissionNumber);
                    table.ForeignKey(
                        name: "FK_SupplyPermissions_BusinessPartners_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "BusinessPartners",
                        principalColumn: "PartnerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplyPermissions_Permissions_PermissionNumber",
                        column: x => x.PermissionNumber,
                        principalTable: "Permissions",
                        principalColumn: "PermissionNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferPermissions",
                columns: table => new
                {
                    PermissionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DestWarehouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferPermissions", x => x.PermissionNumber);
                    table.ForeignKey(
                        name: "FK_TransferPermissions_Permissions_PermissionNumber",
                        column: x => x.PermissionNumber,
                        principalTable: "Permissions",
                        principalColumn: "PermissionNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferPermissions_Warehouses_DestWarehouseID",
                        column: x => x.DestWarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ItemCode",
                table: "InventoryItems",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionItems_ItemCode",
                table: "PermissionItems",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionItems_PermissionNumber",
                table: "PermissionItems",
                column: "PermissionNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_MainWarehouseID",
                table: "Permissions",
                column: "MainWarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionDate",
                table: "Permissions",
                column: "PermissionDate");

            migrationBuilder.CreateIndex(
                name: "IX_ReleasePermissions_CustomerID",
                table: "ReleasePermissions",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPermissions_SupplierID",
                table: "SupplyPermissions",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferPermissions_DestWarehouseID",
                table: "TransferPermissions",
                column: "DestWarehouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "PermissionItems");

            migrationBuilder.DropTable(
                name: "ReleasePermissions");

            migrationBuilder.DropTable(
                name: "SupplyPermissions");

            migrationBuilder.DropTable(
                name: "TransferPermissions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "BusinessPartners");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
