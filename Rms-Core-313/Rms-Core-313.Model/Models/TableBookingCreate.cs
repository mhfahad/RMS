using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rms_Core_313.Model.Models
{
    public class TableBookingCreate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsMailConfirm { get; set; }
        public bool IsBokkingConfirm { get; set; }
        public bool IsReject{ get; set; }
        public int GuestAmount { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public string Note { get; set; }
    }
}
