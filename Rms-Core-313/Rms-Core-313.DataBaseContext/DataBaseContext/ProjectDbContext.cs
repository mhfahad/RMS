using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rms_Core_313.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rms_Core_313.DataBaseContext.DataBaseContext
{
    public class ProjectDbContext: IdentityDbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<MenusCreate> menusCreates { get; set; }
        public DbSet<CreateType> createTypes { get; set; }
        public DbSet<TableBookingCreate> tableBookingCreates { get; set; }
        public DbSet<OrderPlace> OrderPlaces { get; set; }
        public DbSet<OrderPlaceDetails> OrderPlaceDetails { get; set; }
      
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string connectionString = "Server=DESKTOP-9O43VA7; Database=Rms-Core; Integrated Security=true";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
