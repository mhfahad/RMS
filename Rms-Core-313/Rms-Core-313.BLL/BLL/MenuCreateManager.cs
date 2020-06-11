using Rms_Core_313.BLL.Interface;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Repository.Interface;
using Rms_Core_313.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.BLL.BLL
{
    public class MenuCreateManager : IMenuCreateManager
    {
        IMenuCreaterepository _Repository;

        public MenuCreateManager(IMenuCreaterepository Repository)
        {
            _Repository = Repository;
        }

        public bool Create(MenusCreate menus)
        {

            return _Repository.Create(menus);
        }
        public bool UpdateActivity(int id)
        {

            return _Repository.UpdateActivity(id);
        }
        public List<MenusCreate> GetMenus()
        {
            return _Repository.GetMenus();
        }
        public bool Delete(MenusCreate menus)
        {
            return _Repository.Delete(menus);
        }
        public bool CreateType(CreateType type)
        {
            return _Repository.CreateType(type);

        }

        public List<CreateType> GetMenuType()
        {
            return _Repository.GetType();
        }
        public List<MenusCreate> GetMenuList()
        {
            return _Repository.GetMenuList();
        }
        public List<MenusCreate> GetMenuListByType(int id)
        {
            return _Repository.GetMenuListByType(id);
        }
        public List<MenusCreate> GetMenuListByType()
        {
            return _Repository.GetMenuListByType();
        }
    }
}
