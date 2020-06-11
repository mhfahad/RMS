using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rms_Core_313.BLL.BLL;
using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Models;
using Rms_Core_313.Models.Vm;
using Stripe;
using Microsoft.AspNetCore.Identity;

namespace Rms_Core_313.Controllers
{
    public class OnlineOrderController : Controller
    {
        private readonly IOrderPlaceManager manager;
        private readonly IMapper _mapper;
      
        public OnlineOrderController(IOrderPlaceManager _manager, IMapper mapper)
        {
            manager = _manager;
            _mapper = mapper;
          
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(OrderPlaceVm vm)
        {
            if (ModelState.IsValid && vm.OrderPlaceDetails != null && vm.ReciverPhone!= null)
            {
                OrderPlaceVm Order = new OrderPlaceVm();
                var entity = _mapper.Map<OrderPlace>(vm);
                entity.UserId = User.Identity.Name;
                entity.date = DateTime.Today;
                var data = manager.Create(entity);
                //vm.OrderPlaces = manager.GetOrderPlacesList();
                if (vm.IsCashOnDelivery == "on" && data == true)
                {

                    var quentity = 0;
                    var amount = 0.00;

                    foreach (var item in vm.OrderPlaceDetails)
                    {
                        //List<OrderPlaceDetails> i = manager.GetOrderPlacesById(List<long> Ids);
                        //name += item.menusCreate.Name + ",";
                        quentity += item.Quantity;
                        amount += (item.Quantity * item.Price);
                    }
                    return RedirectToAction("PaymentGetwayFeedback" );
                }
                else
                {

                    var quentity = 0;
                    var amount = 0.00;

                    foreach (var item in vm.OrderPlaceDetails)
                    {
                        //List<OrderPlaceDetails> i = manager.GetOrderPlacesById(List<long> Ids);
                        //name += item.menusCreate.Name + ",";
                        quentity += item.Quantity;
                        amount += (item.Quantity * item.Price);
                    }
                    return RedirectToAction("PaymentGetwayIntegrate", new { quantity = quentity, amount = amount });
                }

            }
            else
            {
                ViewBag.Validdata = false;
                return View();
            }
           
        }
        public ActionResult PaymentGetwayIntegrate(int quantity,int amount)
        {
            StripeSetting student = new StripeSetting { Quantity = quantity, Amount = amount};
            return View(student);
        }
        [HttpPost]
        public ActionResult PaymentGetwayIntegrate(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Test Payment",
                Currency = "GBP",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail,
                Metadata = new Dictionary<string, string>()
                {
                    {"OrderId","111"},
                    { "PostCode","E15NB"},
                }
            });

            if (charge.Status == "succeeded" || charge.Status == "pending" || charge.Status == "failed")
            {
                string BalanceTranjectionId = charge.BalanceTransactionId;
                return RedirectToAction("PaymentGetwayFeedback");
            }
            else
            {

            }
            return View();
        }
        [Authorize]
        public ActionResult PaymentGetwayFeedback()
        {
            var oData = new OrderPlace();
            var uData= manager.GetLatestIdByUser(User.Identity.Name);
            var sData=uData.LastOrDefault();
            oData.IsComplitePayment = true;
            oData.Id = sData.Id;
            manager.Update(oData);
            return View();
        }
        public ActionResult GetOrderList()
        {
            var order = new OrderPlaceVm();
            order.Email= manager.GetUserById(User.Identity.Name);
            order.OrderPlaces = manager.GetOrderPlacesList();
            return View(order);
        }

    }
}