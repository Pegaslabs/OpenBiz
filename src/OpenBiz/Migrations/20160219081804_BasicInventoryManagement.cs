using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace OpenBiz.Migrations
{
    public partial class BasicInventoryManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ProductDateOut", table: "Product");
            migrationBuilder.DropColumn(name: "ProductQuantityOnHand", table: "Product");
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    ParentCategoryCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_ProductCategory_ProductCategory_ParentCategoryCategoryID",
                        column: x => x.ParentCategoryCategoryID,
                        principalTable: "ProductCategory",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierAddress = table.Column<string>(nullable: true),
                    SupplierName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });
            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaximumCapacity = table.Column<int>(nullable: false),
                    RemainingCapacity = table.Column<int>(nullable: false),
                    WarehouseLocation = table.Column<string>(nullable: true),
                    WarehouseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseID);
                });
            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartName = table.Column<string>(nullable: true),
                    PartPrice = table.Column<decimal>(nullable: false),
                    PartQuantity = table.Column<int>(nullable: false),
                    WarehouseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.PartID);
                    table.ForeignKey(
                        name: "FK_Part_Warehouse_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "RawMaterial",
                columns: table => new
                {
                    MaterialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(nullable: true),
                    MaterialName = table.Column<string>(nullable: true),
                    MaterialPrice = table.Column<int>(nullable: false),
                    MaterialQuantity = table.Column<int>(nullable: false),
                    ProductProductID = table.Column<int>(nullable: true),
                    SupplierID = table.Column<int>(nullable: false),
                    WarehouseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterial", x => x.MaterialID);
                    table.ForeignKey(
                        name: "FK_RawMaterial_Product_ProductProductID",
                        column: x => x.ProductProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RawMaterial_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterial_Warehouse_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "ProductParts",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    PartID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductParts", x => new { x.ProductID, x.PartID });
                    table.ForeignKey(
                        name: "FK_ProductParts_Part_PartID",
                        column: x => x.PartID,
                        principalTable: "Part",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductParts_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialID = table.Column<int>(nullable: false),
                    QuoteDescription = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    SupplierSupplierID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteID);
                    table.ForeignKey(
                        name: "FK_Quotes_RawMaterial_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "RawMaterial",
                        principalColumn: "MaterialID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quotes_Supplier_SupplierSupplierID",
                        column: x => x.SupplierSupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AlterColumn<decimal>(
                name: "ProductPrice",
                table: "Product",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOut",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<int>(
                name: "QuantityOnHand",
                table: "Product",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "WarehouseID",
                table: "Product",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "ProductCategory",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Warehouse_WarehouseID",
                table: "Product",
                column: "WarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Product_ProductCategory_CategoryID", table: "Product");
            migrationBuilder.DropForeignKey(name: "FK_Product_Warehouse_WarehouseID", table: "Product");
            migrationBuilder.DropColumn(name: "CategoryID", table: "Product");
            migrationBuilder.DropColumn(name: "DateOut", table: "Product");
            migrationBuilder.DropColumn(name: "QuantityOnHand", table: "Product");
            migrationBuilder.DropColumn(name: "WarehouseID", table: "Product");
            migrationBuilder.DropTable("ProductCategory");
            migrationBuilder.DropTable("ProductParts");
            migrationBuilder.DropTable("Quotes");
            migrationBuilder.DropTable("Part");
            migrationBuilder.DropTable("RawMaterial");
            migrationBuilder.DropTable("Supplier");
            migrationBuilder.DropTable("Warehouse");
            migrationBuilder.AlterColumn<int>(
                name: "ProductPrice",
                table: "Product",
                nullable: false);
            migrationBuilder.AddColumn<DateTime>(
                name: "ProductDateOut",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantityOnHand",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }
    }
}
