using Microsoft.AspNet.Mvc.Rendering;
using OpenBiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Http;

namespace OpenBiz.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [StringLength(27,MinimumLength =7)]
        public string ProductName { get; set; }

        [Range(0,9999999999999999)]
        public decimal ProductPrice { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 19)]
        public string ProductDescription { get; set; }

        [Range(0,20000)]
        public int QuantityOnHand { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOut { get; set; }

        public List<ProductCategory> Categories { get; set; }

        [Required(ErrorMessage = "Please Select a Product Category")]
        [Display(Name = "Select Category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Please Upload a Valid Image File")]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Product Image (\".png\", \".jpg\", \".jpeg\" and \".gif\")")]
        [FileExtensions()]
        public IFormFile ProductImage { get; set; }

    }
}
