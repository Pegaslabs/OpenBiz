using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenBiz.Models
{
    public class RawMaterial
    {
        [Key]
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public string Manufacturer { get; set; }

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        public int MaterialPrice { get; set; }
        public int MaterialQuantity { get; set; }

        public ICollection<WarehouseMaterials> Warehouses { get; set; }
    }
}