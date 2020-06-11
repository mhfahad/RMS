using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.Repository.Interface
{
    public interface IMenuCreaterepository
    {
        bool Create(MenusCreate menus);
        bool UpdateActivity(int id);
        bool Delete(MenusCreate menus);
        List<MenusCreate> GetMenus();
        bool CreateType(CreateType type);
        List<CreateType> GetType();
        List<MenusCreate> GetMenuList();
        List<MenusCreate> GetMenuListByType(int id);
        List<MenusCreate> GetMenuListByType();
    }
}
