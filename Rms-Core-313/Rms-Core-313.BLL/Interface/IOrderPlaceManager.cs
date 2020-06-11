using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.BLL.Interface
{
    public interface IOrderPlaceManager
    {
        bool Create(OrderPlace order);
        List<OrderPlace> GetOrderPlacesList();
        bool Update(OrderPlace order);
        string GetUserById(string UserName);
        OrderPlace GetById(OrderPlace order);
        List<OrderPlace> GetLatestIdByUser(string UserName);
    }
}
