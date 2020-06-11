using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rms_Core_313.Model.Models
{
    public class MenusCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreateTypeId { get; set; }
        public virtual CreateType CreateType { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public string Discriptions { get; set; }
        public byte[] Data { get; set; }
        [NotMapped]
        public string Images { get; set; }
    }
}
