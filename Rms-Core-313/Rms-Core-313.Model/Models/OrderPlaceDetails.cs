using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.Model.Models
{
    public class OrderPlaceDetails
    {
        public long Id { get; set; }
        public int MenusCreateId { get; set; }
        public virtual MenusCreate menusCreate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public long PlaceOrderId { get; set; }
        //public OrderPlace OrderPlace { get; set; }
    }
}
