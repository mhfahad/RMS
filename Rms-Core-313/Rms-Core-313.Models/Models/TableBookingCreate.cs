using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.Models.Models
{
    public class TableBookingCreate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsMailConfirm { get; set; }
        public bool IsBokkingConfirm { get; set; }
        public int GuestAmount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}
