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
    public class OrderPlaceRepository : IOrderPlaceRepository
    {
        ProjectDbContext Db;
        public OrderPlaceRepository(DbContext db)
        {
            Db = (ProjectDbContext)db;
        }
        public bool Create(OrderPlace order)
        {

            Db.OrderPlaces.Add(order);
            return 0 < Db.SaveChanges();
        }

        public OrderPlace GetById(OrderPlace order)
        {
            var data= Db.OrderPlaces.Where(c => c.Id == order.Id).SingleOrDefault();
            data.Email = GetUserById(data.UserId);
            return data;
        }

        public List<OrderPlace> GetOrderPlacesList()
        {
            var list = Db.OrderPlaces.Where(c=>c.IsComplitePayment==true) .OrderByDescending(c=>c.Id).ToList();
            
            return list;
        }
        public string GetUserById(string UserName)
        {
            return Db.Users.Where(c => c.UserName == UserName).Select(i => i.Email).SingleOrDefault();
        }
        public List<OrderPlace> GetLatestIdByUser(string UserName)
        {
            return Db.OrderPlaces.Where(c => c.UserId == UserName).ToList();
        }
        public bool Update(OrderPlace order)
        {
            OrderPlace aModel = new OrderPlace();

            aModel = Db.OrderPlaces.Where(c => c.Id == order.Id).SingleOrDefault();
           
            else if(order.IsComplitePayment)
            {
                aModel.IsComplitePayment = true;
            }
            return 0< Db.SaveChanges();
        }
    }
}
