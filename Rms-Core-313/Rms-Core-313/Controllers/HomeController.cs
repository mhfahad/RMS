using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rms_Core_313.BLL.BLL;
using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Models;

namespace Rms_Core_313.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMenuCreateManager manager;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IMenuCreateManager _manager, IMapper mapper)
        {
            _logger = logger;
            manager = _manager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = new MenuCreateVm();
            model.Menus = manager.GetMenus();
            return View(model);
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
