using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using OpenBiz.Models;

namespace OpenBiz.Migrations
{
    [DbContext(typeof(SCMSContext))]
    [Migration("20160316091409_tweaks5")]
    partial class tweaks5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("OpenBiz.Models.Part", b =>
                {
                    b.Property<int>("PartID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PartName");

                    b.Property<decimal>("PartPrice");

                    b.Property<int>("PartQuantity");

                    b.HasKey("PartID");
                });

            modelBuilder.Entity("OpenBiz.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("DateOut");

                    b.Property<int>("ImageID");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductName");

                    b.Property<decimal>("ProductPrice");

                    b.Property<int>("QuantityOnHand");

                    b.HasKey("ProductID");

                    b.HasAlternateKey("ProductName")
                        .HasAnnotation("Relational:Name", "AlteranteKey_ProductName");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<int?>("ParentCategoryCategoryID");

                    b.HasKey("CategoryID");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductImage", b =>
                {
                    b.Property<string>("Hash");

                    b.Property<string>("Extension");

                    b.Property<int>("ProductID");

                    b.HasKey("Hash");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductParts", b =>
                {
                    b.Property<int>("ProductID");

                    b.Property<int>("PartID");

                    b.HasKey("ProductID", "PartID");
                });

            modelBuilder.Entity("OpenBiz.Models.Quotes", b =>
                {
                    b.Property<int>("QuoteID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaterialID");

                    b.Property<int>("QuoteDescription");

                    b.Property<bool>("Status");

                    b.Property<int?>("SupplierSupplierID");

                    b.HasKey("QuoteID");
                });

            modelBuilder.Entity("OpenBiz.Models.RawMaterial", b =>
                {
                    b.Property<int>("MaterialID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manufacturer");

                    b.Property<string>("MaterialName");

                    b.Property<int>("MaterialPrice");

                    b.Property<int>("MaterialQuantity");

                    b.Property<int?>("ProductProductID");

                    b.Property<int>("SupplierID");

                    b.HasKey("MaterialID");
                });

            modelBuilder.Entity("OpenBiz.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SupplierAddress");

                    b.Property<string>("SupplierName");

                    b.HasKey("SupplierID");
                });

            modelBuilder.Entity("OpenBiz.Models.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("OpenBiz.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaximumCapacity");

                    b.Property<int?>("PartPartID");

                    b.Property<int>("RemainingCapacity");

                    b.Property<string>("WarehouseLocation");

                    b.Property<string>("WarehouseName");

                    b.HasKey("WarehouseID");
                });

            modelBuilder.Entity("OpenBiz.Models.WarehouseMaterials", b =>
                {
                    b.Property<int>("RawMaterialID");

                    b.Property<int>("WarehouseID");

                    b.HasKey("RawMaterialID", "WarehouseID");
                });

            modelBuilder.Entity("OpenBiz.Models.WarehouseProducts", b =>
                {
                    b.Property<int>("ProductID");

                    b.Property<int>("WarehouseID");

                    b.HasKey("ProductID", "WarehouseID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OpenBiz.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OpenBiz.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("OpenBiz.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OpenBiz.Models.Product", b =>
                {
                    b.HasOne("OpenBiz.Models.ProductCategory")
                        .WithMany()
                        .HasForeignKey("CategoryID");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductCategory", b =>
                {
                    b.HasOne("OpenBiz.Models.ProductCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryCategoryID");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductImage", b =>
                {
                    b.HasOne("OpenBiz.Models.Product")
                        .WithOne()
                        .HasForeignKey("OpenBiz.Models.ProductImage", "ProductID");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductParts", b =>
                {
                    b.HasOne("OpenBiz.Models.Part")
                        .WithMany()
                        .HasForeignKey("PartID");

                    b.HasOne("OpenBiz.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("OpenBiz.Models.Quotes", b =>
                {
                    b.HasOne("OpenBiz.Models.RawMaterial")
                        .WithMany()
                        .HasForeignKey("MaterialID");

                    b.HasOne("OpenBiz.Models.Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierSupplierID");
                });

            modelBuilder.Entity("OpenBiz.Models.RawMaterial", b =>
                {
                    b.HasOne("OpenBiz.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductProductID");

                    b.HasOne("OpenBiz.Models.Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID");
                });

            modelBuilder.Entity("OpenBiz.Models.Warehouse", b =>
                {
                    b.HasOne("OpenBiz.Models.Part")
                        .WithMany()
                        .HasForeignKey("PartPartID");
                });

            modelBuilder.Entity("OpenBiz.Models.WarehouseMaterials", b =>
                {
                    b.HasOne("OpenBiz.Models.RawMaterial")
                        .WithMany()
                        .HasForeignKey("RawMaterialID");

                    b.HasOne("OpenBiz.Models.Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseID");
                });

            modelBuilder.Entity("OpenBiz.Models.WarehouseProducts", b =>
                {
                    b.HasOne("OpenBiz.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.HasOne("OpenBiz.Models.Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseID");
                });
        }
    }
}
