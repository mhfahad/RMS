using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rms_Core_313.Models
{
    public class MenuCreateVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreateTypeId { get; set; }
        public virtual CreateType createType { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public string Discriptions { get; set; }
        public byte[] Data { get; set; }
        public IFormFile Images { get; set; }
        public List<MenusCreate> Menus { get; set; }

        public DateTime? ToDate { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }
    }
}
