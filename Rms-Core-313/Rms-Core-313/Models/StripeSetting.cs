using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rms_Core_313.Models
{
    public class StripeSetting
    {
        public string Publishablekey { get; set; }
        public string Secretkey { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
    }
}
