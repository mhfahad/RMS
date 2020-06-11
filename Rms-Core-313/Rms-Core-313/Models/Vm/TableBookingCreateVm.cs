using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rms_Core_313.Models.Vm
{
    public class TableBookingCreateVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsMailConfirm { get; set; }
        public bool IsBokkingConfirm { get; set; }
        public bool IsReject { get; set; }
        public int GuestAmount { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        
        public string Note { get; set; }
        public List<TableBookingCreate> tableBookingCreates { get; set; }
    }
}
