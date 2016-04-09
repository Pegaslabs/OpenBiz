using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using OpenBiz.Models;

namespace OpenBiz.Migrations
{
    [DbContext(typeof(Models.SCMSContext))]
    [Migration("20160211180534_InitializeDatabase")]
    partial class InitializeDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OpenBiz.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ProductDateOut");

                    b.Property<string>("ProductDescription");

                    b.Property<string>("ProductName");

                    b.Property<int>("ProductPrice");

                    b.Property<int>("ProductQuantityOnHand");

                    b.HasKey("ProductID");
                });
        }
    }
}
