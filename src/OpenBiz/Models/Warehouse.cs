using System.Collections.Generic;

namespace OpenBiz.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }
        public int MaximumCapacity { get; set; }
        public int RemainingCapacity { get; set; }

        public ICollection<WarehouseProducts> Products { get; set; }
        public ICollection<WarehouseMaterials> Materials { get; set; }
    }
}