using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using OpenBiz.Models;

namespace OpenBiz.Migrations
{
    [DbContext(typeof(Models.SCMSContext))]
    [Migration("20160219081804_BasicInventoryManagement")]
    partial class BasicInventoryManagement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenBiz.Models.Part", b =>
                {
                    b.Property<int>("PartID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PartName");

                    b.Property<decimal>("PartPrice");

                    b.Property<int>("PartQuantity");

                    b.Property<int>("WarehouseID");

                    b.HasKey("PartID");
                });

            modelBuilder.Entity("OpenBiz.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("DateOut");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductName");

                    b.Property<decimal>("ProductPrice");

                    b.Property<int>("QuantityOnHand");

                    b.Property<int>("WarehouseID");

                    b.HasKey("ProductID");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<int?>("ParentCategoryCategoryID");

                    b.HasKey("CategoryID");
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

                    b.Property<int>("WarehouseID");

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

            modelBuilder.Entity("OpenBiz.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaximumCapacity");

                    b.Property<int>("RemainingCapacity");

                    b.Property<string>("WarehouseLocation");

                    b.Property<string>("WarehouseName");

                    b.HasKey("WarehouseID");
                });

            modelBuilder.Entity("OpenBiz.Models.Part", b =>
                {
                    b.HasOne("OpenBiz.Models.Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseID");
                });

            modelBuilder.Entity("OpenBiz.Models.Product", b =>
                {
                    b.HasOne("OpenBiz.Models.ProductCategory")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("OpenBiz.Models.Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseID");
                });

            modelBuilder.Entity("OpenBiz.Models.ProductCategory", b =>
                {
                    b.HasOne("OpenBiz.Models.ProductCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryCategoryID");
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

                    b.HasOne("OpenBiz.Models.Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseID");
                });
        }
    }
}
