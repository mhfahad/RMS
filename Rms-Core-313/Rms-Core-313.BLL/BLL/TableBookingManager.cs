using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.BLL.BLL
{
    public class TableBookingManager : ITableBookingManager
    {
        ITableBookingRepository repository;

        public TableBookingManager(ITableBookingRepository _Repository)
        {
             repository= _Repository;
        }
        public bool Create(TableBookingCreate model)
        {
            return repository.Create(model);
        }
        public void ConfirmBooking(long id)
        {
            repository.ConfirmBooking(id);
        }
        public TableBookingCreate GetById(long Id)
        {
            return repository.GetById(Id);
        }
        public long LetestId(string Phone)
        {
            return repository.LetestId(Phone);
        }
        public void ConfirmMail(long id)
        {
            repository.ConfirmMail(id);
        }
        public void Reject(long id)
        {
            repository.Reject(id);
        }
        public List<TableBookingCreate> GetBookingList()
        {
            return repository.GetBookingList();
        }
    }
}
