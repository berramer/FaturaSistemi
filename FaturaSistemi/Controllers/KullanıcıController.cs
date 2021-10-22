using Business;
using DataAcces.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaSistemi.Controllers
{
    public class KullanıcıController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new CustomerDal ());
        public JsonResult kullanıcıKontrol(string identity,string password)
        {
            string mesaj = customerManager.kullanıcıKontrol(identity, password);
            if (mesaj.Equals("Giriş Başarılı"))
            {
                HttpContext.Session.SetString("oturum", identity);
            }
            return Json(mesaj);
        }


        public JsonResult sifreyenile(string sifre )
        {
            string ıdentity = HttpContext.Session.GetString("oturum");
            string mesaj = customerManager.sifreyenile(ıdentity, sifre);
            return Json(mesaj);
        }
        public JsonResult  profilbilgileri(string sifre)
        {
            string ıdentity = HttpContext.Session.GetString("oturum");
            Customer customer = customerManager.profil(ıdentity);
            return Json(customer);
        }
       
        public JsonResult kullanıcı_ekle(string Name,string LastName,string CustomerIdentity,string address,string TelNo, string uyelıkler,string password)
        {
            try
            {
                Customer customer = new Customer
                {
                    customerName = Name,
                    customerLastName= LastName,
                    customerIdentity= CustomerIdentity,
                    customerAddress= address,
                    customerPhoneNumber= TelNo,
                    memberships=uyelıkler,
                    password= password,
                };
                customerManager.kisi_ekle(customer);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
          
            return Json("Başarılı");
        }
    }
}
