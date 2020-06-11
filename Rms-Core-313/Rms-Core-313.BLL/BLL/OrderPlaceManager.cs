using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.BLL.BLL
{
    public class OrderPlaceManager : IOrderPlaceManager
    {
        IOrderPlaceRepository repository;

        public OrderPlaceManager(IOrderPlaceRepository _Repository)
        {
            repository = _Repository;
        }

        public bool Create(OrderPlace order)
        {
            return repository.Create(order);
        }

        public OrderPlace GetById(OrderPlace order)
        {
            return repository.GetById(order);
        }

        public List<OrderPlace> GetLatestIdByUser(string UserName)
        {
            return repository.GetLatestIdByUser(UserName);
        }

        public List<OrderPlace> GetOrderPlacesList()
        {
            return repository.GetOrderPlacesList();
        }

        public string GetUserById(string UserName)
        {
            return repository.GetUserById(UserName);
        }

        public bool Update(OrderPlace order)
        {
            return repository.Update(order);
        }
    }
}
