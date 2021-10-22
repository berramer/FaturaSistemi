using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete
{
   public  class WebContext:DbContext
    {

        DbSet<Customer>Customers { get; set; }
        DbSet<Invoice>Invoices { get; set; }
        DbSet<SystemUser>SystemUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B28EHI3;Database=FaturaÖdemeSistemi;User Id=sa;Password=berra123;");
        }
    }
}
