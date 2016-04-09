using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace OpenBiz.Migrations
{
    public partial class foreignkey : Migration
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
            migrationBuilder.DropColumn(name: "CategoryID", table: "Product");
            migrationBuilder.DropColumn(name: "WarehouseID", table: "Product");
            migrationBuilder.AddColumn<int>(
                name: "CategoryCategoryID",
                table: "Product",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "WarehouseWarehouseID",
                table: "Product",
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
                name: "FK_Part_Warehouse_WarehouseID",
                table: "Part",
                column: "WarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryCategoryID",
                table: "Product",
                column: "CategoryCategoryID",
                principalTable: "ProductCategory",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Warehouse_WarehouseWarehouseID",
                table: "Product",
                column: "WarehouseWarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_RawMaterial_Warehouse_WarehouseID",
                table: "RawMaterial",
                column: "WarehouseID",
                principalTable: "Warehouse",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_Part_Warehouse_WarehouseID", table: "Part");
            migrationBuilder.DropForeignKey(name: "FK_Product_ProductCategory_CategoryCategoryID", table: "Product");
            migrationBuilder.DropForeignKey(name: "FK_Product_Warehouse_WarehouseWarehouseID", table: "Product");
            migrationBuilder.DropForeignKey(name: "FK_ProductParts_Part_PartID", table: "ProductParts");
            migrationBuilder.DropForeignKey(name: "FK_Quotes_RawMaterial_MaterialID", table: "Quotes");
            migrationBuilder.DropForeignKey(name: "FK_RawMaterial_Supplier_SupplierID", table: "RawMaterial");
            migrationBuilder.DropForeignKey(name: "FK_RawMaterial_Warehouse_WarehouseID", table: "RawMaterial");
            migrationBuilder.DropColumn(name: "CategoryCategoryID", table: "Product");
            migrationBuilder.DropColumn(name: "WarehouseWarehouseID", table: "Product");
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Product",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "WarehouseID",
                table: "Product",
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
