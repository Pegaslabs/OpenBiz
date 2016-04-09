using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenBiz.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime DateOut { get; set; }

        public int CategoryID { get; set; }
        public ProductCategory Category { get; set; }

        public string Barcode { get; set; }

        public int UID { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        public ICollection<WarehouseProducts> Warehouses { get; set; }
        public ICollection<ProductParts> Parts { get; set; }
        public ICollection<RawMaterial> RawMaterials { get; set; }
    }
}