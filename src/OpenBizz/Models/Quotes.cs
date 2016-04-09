using System.ComponentModel.DataAnnotations;

namespace OpenBiz.Models
{
    public class Quotes
    {
        [Key]
        public int QuoteID { get; set; }
        public int QuoteDescription { get; set; }

        public int MaterialID { get; set; }
        public RawMaterial RawMaterial { get; set; }

        public bool Status { get; set; }

    }
}