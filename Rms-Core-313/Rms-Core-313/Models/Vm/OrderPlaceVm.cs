using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rms_Core_313.Models.Vm
{
    public class OrderPlaceVm
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string Email { get; set; }
        public string IsCashOnDelivery { get; set; }
   
        public string ReciverPhone { get; set; }
        public bool IsInKichen { get; set; }
        public bool IsDelivering { get; set; }
        public bool IsRecived { get; set; }
        public virtual ICollection<OrderPlaceDetails> OrderPlaceDetails { get; set; }
        public List<OrderPlace> OrderPlaces { get; set; }
    }
}
