using Business;
using DataAcces.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaSistemi.Controllers
{
    public class AdminController : Controller
    {
         SystemUserManager systemUser = new SystemUserManager(new SystemUserDal());
        public JsonResult kullanıcıKontrol(string username, string password)
        {
            string mesaj = systemUser.kullanıcıKontrol(username, password);
            return Json(mesaj);
        }


        public JsonResult adminekle(string userName,string UserLastName,string SystemUserName,string email,string password)
        {
            try
            {
                systemUser.adminekle(new Entities.SystemUser
                {
                    UserName = userName,
                    UserLastname= UserLastName,
                    SystemUserName= SystemUserName,
                    email=email,
                    Password=password,
                }) ;
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }

            return Json("Başarılı");

        }




        public void faturaatama()
        {
            CustomerDal a = new CustomerDal();
            InvoiceDal b = new InvoiceDal();
            List<Customer> kullanıcılar = a.getAll();
            for(int i = 0; i < kullanıcılar.Count; i++)
            {
                string[] uyelikler = kullanıcılar[i].memberships.Split(',');
               for(int k = 0; k < uyelikler.Length-1;k++)
                {
                    Random rnd = new Random();
                    b.Add(new Invoice
                    {

                        InvoiceNumber = rnd.Next(1, 10000000),
                        InvoiceSituation = 0,
                        InvoiceType = uyelikler[k],
                        CustomerIdentity = kullanıcılar[i].customerIdentity,
                        InvoiceAmount = rnd.Next(1, 100),
                        InvoiceTime = DateTime.Now,
                        InvoiceDeliveryTime = DateTime.Now.AddMonths(1),
                    }) ;
                    
                }
            }

        }

    }
}
