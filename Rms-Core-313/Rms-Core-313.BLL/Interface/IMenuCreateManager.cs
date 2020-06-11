using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.BLL.Interface
{
    public interface IMenuCreateManager 
    {
        bool Create(MenusCreate menus);
        bool UpdateActivity(int id);
        bool Delete(MenusCreate menus);
        List<CreateType> GetMenuType();
        List<MenusCreate> GetMenus();
        bool CreateType(CreateType type);
        List<MenusCreate> GetMenuList();
        List<MenusCreate> GetMenuListByType(int id);
        List<MenusCreate> GetMenuListByType();


    }
}
