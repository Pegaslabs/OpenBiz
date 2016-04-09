using System.Collections.Generic;

namespace OpenBiz.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public ICollection<Quotes> Quotes { get; set; }
    }
}