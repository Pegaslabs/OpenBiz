using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBiz.Models
{
    public class UnitOfMeasurement
    {
        [Key]
        public int UID { get; set; }

        public string Unit { get; set; }

        public bool IsActive { get; set; }
    }
}
