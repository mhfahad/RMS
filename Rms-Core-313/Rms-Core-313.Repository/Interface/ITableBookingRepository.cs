using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.Repository.Interface
{
    public interface ITableBookingRepository
    {
        bool Create(TableBookingCreate model);
        void ConfirmMail(long id);
        void ConfirmBooking(long id);
        List<TableBookingCreate> GetBookingList();
        TableBookingCreate GetById(long Id);
        void Reject(long id);
        long LetestId(string Phone);
    }
}
