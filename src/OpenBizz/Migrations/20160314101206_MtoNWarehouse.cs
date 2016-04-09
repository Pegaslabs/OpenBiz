using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace OpenBiz.Migrations
{
    public partial class MtoNWarehouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_Part_Warehouse_WarehouseID", table: "Part");
            migrationBuilder.DropForeignKey(name: "FK_Product_ProductCategory_CategoryID", table: "Product");
            migrationBuilder.DropForeignKey(name: "FK_Product_Warehouse_WarehouseID", table: "Product");
            migrationBuilder.DropForeignKey(name: "FK_ProductParts_Part_PartID", table: "ProductParts");
            migrationBuilder.DropForeignKey(name: "FK_Quotes_RawMaterial_MaterialID", table: "Quotes");
            migrationBuilder.DropForeignKey(name: "FK_RawMaterial_Supplier_SupplierID", table: "RawMaterial");
            migrationBuilder.DropForeignKey(name: "FK_RawMaterial_Warehouse_WarehouseID", table: "RawMaterial");
            migrationBuilder.DropColumn(name: "WarehouseID", table: "RawMaterial");
            migrationBuilder.DropColumn(name: "WarehouseID", table: "Product");
            migrationBuilder.DropColumn(name: "WarehouseID", table: "Part");
            migrationBuilder.CreateTable(
                name: "WarehouseMaterials",
                columns: table => new
                {
                    RawMaterialID = table.Column<int>(nullable: false),
                    WarehouseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseMaterials", x => new { x.RawMaterialID, x.WarehouseID });
                    table.ForeignKey(
                        name: "FK_WarehouseMaterials_RawMaterial_RawMaterialID",
                        column: x => x.RawMaterialID,
                        principalTable: "RawMaterial",
                        principalColumn: "MaterialID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseMaterials_Warehouse_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "WarehouseProducts",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    WarehouseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseProducts", x => new { x.ProductID, x.WarehouseID });
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseProducts_Warehouse_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddColumn<int>(
                name: "PartPartID",
                table: "Warehouse",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "ProductCategory",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ProductParts_Part_PartID",
                table: "ProductParts",
                column: "PartID",
                principalTable: "Part",
                principalColumn: "PartID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_RawMaterial_MaterialID",
                table: "Quotes",
                column: "MaterialID",
                principalTable: "RawMaterial",
                principalColumn: "MaterialID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterial_Supplier_SupplierID",
                table: "RawMaterial",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Part_PartPartID",
                table: "Warehouse",
                column: "PartPartID",
                principalTable: "Part",
                principalColumn: "PartID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_Product_ProductCategory_CategoryID", table: "Product");
            migrationBuilder.DropForeignKey(name: "FK_ProductParts_Part_PartID", table: "ProductParts");
            migrationBuilder.DropForeignKey(name: "FK_Quotes_RawMaterial_MaterialID", table: "Quotes");
            migrationBuilder.DropForeignKey(name: "FK_RawMaterial_Supplier_SupplierID", table: "RawMaterial");
            migrationBuilder.DropForeignKey(name: "FK_Warehouse_Part_PartPartID", table: "Warehouse");
            migrationBuilder.DropColumn(name: "PartPartID", table: "Warehouse");
            migrationBuilder.DropTable("WarehouseMaterials");
            migrationBuilder.DropTable("WarehouseProducts");
            migrationBuilder.AddColumn<int>(
                name: "WarehouseID",
                table: "RawMaterial",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "WarehouseID",
                table: "Product",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "WarehouseID",
                table: "Part",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Part_Warehouse_WarehouseID",
                table: "Part",
                column: "WarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "ProductCategory",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Warehouse_WarehouseID",
                table: "Product",
                column: "WarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ProductParts_Part_PartID",
                table: "ProductParts",
                column: "PartID",
                principalTable: "Part",
                principalColumn: "PartID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_RawMaterial_MaterialID",
                table: "Quotes",
                column: "MaterialID",
                principalTable: "RawMaterial",
                principalColumn: "MaterialID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterial_Supplier_SupplierID",
                table: "RawMaterial",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterial_Warehouse_WarehouseID",
                table: "RawMaterial",
                column: "WarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
