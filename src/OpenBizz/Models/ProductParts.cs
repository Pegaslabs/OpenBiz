namespace OpenBiz.Models
{
    public class ProductParts
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int PartID { get; set; }
        public Part Part { get; set; }
    }
}