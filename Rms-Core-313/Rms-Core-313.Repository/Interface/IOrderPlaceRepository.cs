using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.Repository.Interface
{
    public interface IOrderPlaceRepository
    {
        bool Create(OrderPlace order);
        List<OrderPlace> GetOrderPlacesList();
        string GetUserById(string UserName);

        bool Update(OrderPlace order);
        OrderPlace GetById(OrderPlace order);
        List<OrderPlace> GetLatestIdByUser(string UserName);

    }
}
