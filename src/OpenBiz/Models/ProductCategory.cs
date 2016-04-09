using System.ComponentModel.DataAnnotations;

namespace OpenBiz.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ProductCategory ParentCategory { get; set; }
    }
}