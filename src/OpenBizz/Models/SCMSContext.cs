using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.Models
{
    public class SCMSContext : IdentityDbContext<User>
    {
        public SCMSContext()
        {
            Database.EnsureCreated();
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ProductParts> ProductParts { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProducts> WarehouseProducts { get; set; }
        public DbSet<WarehouseMaterials> WarehouseMaterials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Quotes> Quotes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = Startup.Configuration["Data:SCMSContextConnection"].ToString();

            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductName)
                .HasName("AlteranteKey_ProductName");

            modelBuilder.Entity<ProductParts>()
                .HasKey(t => new { t.ProductID, t.PartID });


            modelBuilder.Entity<ProductParts>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.Parts)
                .HasForeignKey(pt => pt.ProductID).OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductParts>()
                .HasOne(pt => pt.Part)
                .WithMany(t => t.ProductParts)
                .HasForeignKey(pt => pt.PartID);

            modelBuilder.Entity<WarehouseProducts>()
                .HasKey(t => new { t.ProductID, t.WarehouseID });


            modelBuilder.Entity<WarehouseProducts>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.Warehouses)
                .HasForeignKey(pt => pt.ProductID).OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<WarehouseProducts>()
                .HasOne(pt => pt.Warehouse)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.WarehouseID);

            modelBuilder.Entity<WarehouseMaterials>()
    .HasKey(t => new { t.RawMaterialID, t.WarehouseID });


            modelBuilder.Entity<WarehouseMaterials>()
                .HasOne(pt => pt.RawMaterial)
                .WithMany(p => p.Warehouses)
                .HasForeignKey(pt => pt.RawMaterialID).OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Restrict);

            modelBuilder.Entity<WarehouseMaterials>()
                .HasOne(pt => pt.Warehouse)
                .WithMany(t => t.Materials)
                .HasForeignKey(pt => pt.WarehouseID);

        }
    }


}
