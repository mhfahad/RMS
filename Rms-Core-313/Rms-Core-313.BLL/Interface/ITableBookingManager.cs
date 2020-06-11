using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.BLL.Interface
{
    public interface ITableBookingManager
    {
        bool Create(TableBookingCreate model);
        void ConfirmBooking(long id);
        TableBookingCreate GetById(long Id);
        long LetestId(string Phone);
        void ConfirmMail(long id);
        void Reject(long id);
        List<TableBookingCreate> GetBookingList();
    }
}
