using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rms_Core_313.Models.Models
{
    public class OrderPlace
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string IsCashOnDelivery { get; set; }
        public virtual ICollection<OrderPlaceDetails> OrderPlaceDetails { get; set; }
    }
}
