using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.Models
{
    public class WarehouseMaterials
    {
        public int RawMaterialID { get; set; }
        public RawMaterial RawMaterial { get; set; }

        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }
        public int Quantity { get; set; }
    }
}
