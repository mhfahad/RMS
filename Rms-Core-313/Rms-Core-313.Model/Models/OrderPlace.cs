using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rms_Core_313.Model.Models
{
    public class OrderPlace
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string Email { get; set; }
        public string IsCashOnDelivery { get; set; }
        public bool IsComplitePayment { get; set; }
        public string ReciverPhone { get; set; }
        public bool IsInKichen { get; set; }
        public bool IsDelivering { get; set; }
        public bool IsRecived { get; set; }
        public virtual ICollection<OrderPlaceDetails> OrderPlaceDetails { get; set; }
    }
}
