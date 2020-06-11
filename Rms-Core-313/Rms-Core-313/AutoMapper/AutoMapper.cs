using AutoMapper;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Models;
using Rms_Core_313.Models.Vm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rms_Core_313.AutoMapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
       

            CreateMap<MenusCreate, MenuCreateVm>();
            CreateMap<MenuCreateVm, MenusCreate>();

            CreateMap<CreateType, CreateTypeVm>();
            CreateMap<CreateTypeVm, CreateType>();
            CreateMap<TableBookingCreate, TableBookingCreateVm>();
            CreateMap<TableBookingCreateVm, TableBookingCreate>();
            CreateMap<OrderPlace, OrderPlaceVm>();
            CreateMap<OrderPlaceVm, OrderPlace>();
        }
    }
}
