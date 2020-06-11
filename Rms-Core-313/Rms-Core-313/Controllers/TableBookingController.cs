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
    public class TableBookingController : Controller
    {
        private readonly ITableBookingManager manager;
        private readonly IMapper _mapper;

        public TableBookingController(ITableBookingManager _manager, IMapper mapper)
        {
            manager = _manager;
            _mapper = mapper;

        }
       public async Task<JsonResult> Create(TableBookingCreateVm vm)
            {
                if (ModelState.IsValid)
            {
              
                var entity = _mapper.Map<TableBookingCreate>(vm);
                var rData = manager.Create(entity);
                if (rData)
                {
                    RequestConfirmMail(entity.Email, manager.LetestId(entity.Phone));
                    return Json(rData);
                }
                else
                {
                    return Json(false);
                }
            }
            return Json(false);
        }
        public void RequestConfirmMail(string to, long id)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("mahmudhasanbd95@gmail.com");
            mail.Subject = "Booking Confirmation";
            string Body = "You Have confirm you booking using this link : https://localhost:44344/TableBooking/ConfirmMail?id=" + id;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("mahmudhasanbd95@gmail.com", "fzfahad010793"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
        public ActionResult ConfirmMail(long id)
        {
            
            manager.ConfirmMail(id);
            return View();

        }

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult GetBookingList()
        {
            var Data = new TableBookingCreateVm();
            Data.tableBookingCreates = manager.GetBookingList();
            return View(Data);
        }
    }
}