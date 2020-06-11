using Microsoft.EntityFrameworkCore;
using Rms_Core_313.DataBaseContext.DataBaseContext;
using Rms_Core_313.Model.Models;
using Rms_Core_313.Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Rms_Core_313.Repository.Repository
{
    public class MenuCreateRepository : IMenuCreaterepository
    {
        ProjectDbContext Db;
        public MenuCreateRepository(DbContext db)
        {
            Db = (ProjectDbContext)db;
        }
        public bool Create(MenusCreate menus)
        {
            //using (BinaryReader br = new BinaryReader(menus.Images.OpenReadStream()))
            //{

            //    menus.files = br.ReadBytes(Convert.ToInt32 (menus.Images.ContentType));
            //}


            //long size = menus.files.Sum(f => f.len);
            //// full path to file in temp location
            //var filePath = Path.GetTempFileName();

            //foreach (var formFile in files)
            //{
            //    if (formFile.Length > 0)
            //    {
            //        using (var stream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await formFile.CopyToAsync(stream);
            //        }
            //    }
            //}
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            Db.menusCreates.Add(menus);
            return 0 < Db.SaveChanges();
        }
        public bool UpdateActivity(int id)
        {
            MenusCreate aMenus = Db.menusCreates.FirstOrDefault(x => x.Id ==id);
            if (aMenus.Active)
            {
                aMenus.Active = false;
            }
            else
            {
                aMenus.Active = true;
            }

            Db.SaveChanges();
            return true;
        }
        public bool Delete(MenusCreate menus)
        {
            MenusCreate aMenus = Db.menusCreates.FirstOrDefault(x => x.Id == menus.Id);
            Db.menusCreates.Remove(aMenus);

            Db.SaveChanges();
            return true;
        }
        public List<MenusCreate> GetMenus()
        {
            var data = Db.menusCreates.Where(c => c.Active == true).ToList();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public bool CreateType(CreateType type)
        {
            Db.createTypes.Add(type);
            return 0 < Db.SaveChanges();
        }

        public List<CreateType> GetType()
        {
            return Db.createTypes.ToList();
        }

        public List<MenusCreate> GetMenuList()
        {
            return Db.menusCreates.ToList();
        }
        public List<MenusCreate> GetMenuListByType(int id)
        {
            return Db.menusCreates.Where(c => c.CreateTypeId == id).ToList();
        }
        public List<MenusCreate> GetMenuListByType()
        {
            return Db.menusCreates.ToList();
        }
    }
}
