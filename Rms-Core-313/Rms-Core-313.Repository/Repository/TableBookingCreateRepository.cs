using Microsoft.EntityFrameworkCore;
using Rms_Core_313.DataBaseContext.DataBaseContext;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rms_Core_313.Repository.Repository
{
    public class TableBookingCreateRepository : ITableBookingRepository
    {
        ProjectDbContext Db;
        public TableBookingCreateRepository(DbContext db)
        {
            Db = (ProjectDbContext)db;
        }
        public bool Create(TableBookingCreate model)
        {
            Db.tableBookingCreates.Add(model);
            return 0 < Db.SaveChanges();
        }
        public void ConfirmMail(long id)
        {
            TableBookingCreate aModel = new TableBookingCreate();

            aModel = Db.tableBookingCreates.Where(c => c.Id == id).SingleOrDefault();
            aModel.IsMailConfirm = true;
            Db.SaveChanges();
        }
        public void ConfirmBooking(long id)
        {
            TableBookingCreate aModel = new TableBookingCreate();

            aModel = Db.tableBookingCreates.Where(c => c.Id == id).SingleOrDefault();
            aModel.IsBokkingConfirm = true;
            Db.SaveChanges();
        }
        public void Reject(long id)
        {
            TableBookingCreate aModel = new TableBookingCreate();

            aModel = Db.tableBookingCreates.Where(c => c.Id == id).SingleOrDefault();
            aModel.IsReject = true;
            aModel.IsMailConfirm = false;
            Db.SaveChanges();
        }
        public List<TableBookingCreate> GetBookingList()
        {

            return Db.tableBookingCreates.Where(c => c.IsMailConfirm == true).ToList();
        }
        public TableBookingCreate GetById(long Id)
        {
            var data = Db.tableBookingCreates.Where(c => c.Id == Id).SingleOrDefault();

            return data;
        }
        public long LetestId(string Phone)
        {
            var data = Db.tableBookingCreates.ToArray();
            var Ndata = data.Where(c=>c.Phone== Phone).Select(C => C.Id).Last();

            return Convert.ToInt64(Ndata);
        }

       
    }
}
