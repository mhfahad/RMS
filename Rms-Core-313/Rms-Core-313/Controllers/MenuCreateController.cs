using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Models;
using Rms_Core_313.Models.Vm;

namespace Rms_Core_313.Controllers
{
    public class MenuCreateController : Controller
    {
        private readonly IMenuCreateManager manager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MenuCreateController(IMenuCreateManager _manager, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            manager = _manager;
            _mapper = mapper;
            webHostEnvironment = hostEnvironment;
        }


        public ActionResult Create()
        {
            MenuCreateVm menu = new MenuCreateVm();
            menu.TypeList = manager.GetMenuType().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return View(menu);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create(MenuCreateVm menu)
        {
           
            if (ModelState.IsValid)
            {

                using (MemoryStream stream = new MemoryStream())
                {
                    await menu.Images.CopyToAsync(stream);
                    menu.Data = stream.ToArray();
                }
               
            }
           var entity = _mapper.Map<MenusCreate>(menu);
           var data = manager.Create(entity);
           menu.TypeList = manager.GetMenuType().Select(c => new SelectListItem()
           {
               Value = c.Id.ToString(),
               Text = c.Name
           }).ToList();
            return RedirectToAction("GetMenuList");
        }
        private string UploadedFile(MenuCreateVm model)
        {
            string uniqueFileName = null;

            if (model.Images != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Images.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Images.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult GetMenuList()
        {
            var entity = new MenuCreateVm();
            entity.Menus = manager.GetMenuList();
            return View(entity);
        }
        public PartialViewResult GetMenuListByType(int id)
        {
            var entity = new MenuCreateVm();
            entity.Menus = manager.GetMenuListByType(id);
            return PartialView("~/Views/Shared/_MainDataForOnlineOrder.cshtml", entity);
        }
        public PartialViewResult GetAllMenuList()
        {
            var entity = new MenuCreateVm();
            entity.Menus = manager.GetMenuListByType();
            return PartialView("~/Views/Shared/_MainDataForOnlineOrder.cshtml", entity);
        }
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult CreateType()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public ActionResult CreateType(CreateTypeVm vm)
        {
            var entity = _mapper.Map<CreateType>(vm);
            manager.CreateType(entity);
            return RedirectToAction("Create");
        }
       
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            MenuCreateVm vm = new MenuCreateVm();
            vm.Id = id;
            var entity = _mapper.Map<MenusCreate>(vm); 
            manager.Delete(entity);
            return RedirectToAction("GetMenuList");
        }
        public async Task<JsonResult> CheckActivity(MenuCreateVm Vm)
        {
            if (Vm.Id != null)
            {
                 var rData = manager.UpdateActivity(Vm.Id);
                return Json(rData);
            }
            return Json(false);
        }
        public async Task<JsonResult> GetTypes()
        {
            var data = manager.GetMenuType();
            return Json(data);
        }
    }
}