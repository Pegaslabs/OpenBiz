using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenBiz.Models
{
    public class Part
    {
        [Key]
        public int PartID { get; set; }
        public string PartName { get; set; }
        public decimal PartPrice { get; set; }
        public int PartQuantity { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }

        public ICollection<ProductParts> ProductParts { get; set; }
    }
}