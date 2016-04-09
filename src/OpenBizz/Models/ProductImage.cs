using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.Models
{
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption:DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public string Hash { get; set; }
        public string Extension { get; set; }
    }
}
