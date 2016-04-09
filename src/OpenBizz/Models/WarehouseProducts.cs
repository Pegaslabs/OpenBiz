using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.Models
{
    public class WarehouseProducts
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int WarehouseID { get; set; }
        public Warehouse Warehouse { get; set; }

        public int Quantity { get; set; }

    }
}
