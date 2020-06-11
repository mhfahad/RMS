using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Models.Vm;

namespace Rms_Core_313.Controllers
{
    public class SendingMailController : Controller
    {
        private readonly ITableBookingManager manager;
        private readonly IOrderPlaceManager _orderPlaceManager;
        private readonly IMapper _mapper;

        public SendingMailController(ITableBookingManager _manager, IOrderPlaceManager orderPlaceManager, IMapper mapper)
        {
            manager = _manager;
            _orderPlaceManager = orderPlaceManager;
            _mapper = mapper;

        }
        public async Task<JsonResult> Index(MailVm vm)
        {

            
            var data = manager.GetById(vm.id);
            if (ModelState.IsValid)
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(data.Email);
                mail.From = new MailAddress("mahmudhasanbd95@gmail.com");
                mail.Subject = "Booking Confirmation";
                mail.Body = vm.mailBody;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("mahmudhasanbd95@gmail.com", "fzfahad010793"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                manager.ConfirmBooking(data.Id);
                return Json(true);
            }
            else
            {
                return Json(false);
            }


            //string to = "mahmudhasanbd95@gmail.com"; //To address    
            //string from = "mhfahad93@gmail.com"; //From address    
            //MailMessage message = new MailMessage(from, to);

            //string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            //message.Subject = "Sending Email Using Asp.Net & C#";
            //message.Body = mailbody;
            ////message.BodyEncoding = Encoding.UTF8;
            ////message.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            //System.Net.NetworkCredential basicCredential1 = new
            //System.Net.NetworkCredential("mhfahad93@gmail.com", "fahad010793fahad");
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = true;
            //client.Credentials = basicCredential1;
            //try
            //{
            //    client.Send(message);
            //}

            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return View();
        }
        //[Authorize(Roles = "SuperAdmin")]
        public async Task<JsonResult> Reject(long id)
        {
          
            var data = manager.GetById(id);

            if (ModelState.IsValid)
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(data.Email);
                mail.From = new MailAddress("mahmudhasanbd95@gmail.com");
                mail.Subject = "Booking Confirmation";
                string Body = "Sorry";

                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("mahmudhasanbd95@gmail.com", "fzfahad010793"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                manager.Reject(data.Id);
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }
      public PartialViewResult mailBody(long id)
        {
            var data = manager.GetById(id);
            var entity = _mapper.Map<TableBookingCreateVm>(data);
            return PartialView(entity);

        }
        public PartialViewResult mailBodyKitchen(long id)
        {
            var data = new OrderPlace();
            data.Id = id;
            var oData = _orderPlaceManager.GetById(data);
            var entity = _mapper.Map<OrderPlaceVm>(oData);
            return PartialView(entity);

        }
    }
}