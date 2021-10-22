using DataAcces.Concrete;
using Entities;
using Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaturaSistemi.Controllers
{
    public class FaturaController : Controller
    {
        InvoiceDal nesne = new InvoiceDal();
        public JsonResult getbyid(int id)
        {

            List<Invoice> mk = nesne.getAll(x => x.InvoiceId == id);
            return Json(mk);
        }

        public JsonResult getall(Boolean durum,string search)
        {   
            var CustomerIdentity = HttpContext.Session.GetString("oturum");
            List<Invoice> mk;

            if (search == null)
            {
                if (durum)
                {
                    mk = nesne.getAll(x => x.CustomerIdentity == CustomerIdentity && x.InvoiceSituation == 0);
                }
                else
                {
                    mk = nesne.getAll(x => x.CustomerIdentity == CustomerIdentity);
                }

            }
            else
            {

                if (durum)
                {
                    mk = nesne.getAll(x => x.CustomerIdentity == CustomerIdentity && x.InvoiceSituation == 0 && x.InvoiceType.Contains(search));
                }
                else
                {
                    mk = nesne.getAll(x => x.CustomerIdentity == CustomerIdentity && x.InvoiceType.Contains(search));
                }
            }
            return Json(mk);
        }

        public JsonResult gettumfatura()
        {
            CustomerDal a = new CustomerDal();
            List<Customer> musteriler = a.getAll();
            List<Invoice> faturalar = nesne.getAll();

            var result = from f in faturalar
                         join m in musteriler on f.CustomerIdentity equals m.customerIdentity
                         select new Invoince_Customer
                         {
                             CustomerIdentity = m.customerIdentity,
                             CustomerName = m.customerName,
                             customerLastName = m.customerLastName,
                             InvoinceAmount = f.InvoiceAmount,
                             InvoinceTime = f.InvoiceTime,
                             InvoinceDeliveryTime = f.InvoiceDeliveryTime,
                             InvoinceNumber = f.InvoiceNumber,
                             InvoinceSituation = f.InvoiceSituation,
                             InvoinceType=f.InvoiceType
                             
                         };
            return Json(result);
        }
        public JsonResult odeme(string id)
        {
            int[] ids = Array.ConvertAll(id.Split(','), s => int.Parse(s));//convert all array
            List<Invoice> ınvoices = nesne.getAll(x => ids.Contains(x.InvoiceId) );

            return Json(ınvoices);

        }
        public JsonResult odemeyapma(string id)
        {
            int[] ids = Array.ConvertAll(id.Split(','), s => int.Parse(s));//convert all array
            List<Invoice> ınvoices = nesne.getAll(x => ids.Contains(x.InvoiceId));
            for (int i = 0; i < ids.Length; i++)
            {
                nesne.Update(new Invoice
                {
                    InvoiceId = ınvoices[i].InvoiceId,
                    InvoiceNumber = ınvoices[i].InvoiceNumber ,
                    InvoiceAmount = ınvoices[i].InvoiceAmount,
                    InvoiceType = ınvoices[i].InvoiceType,
                    CustomerIdentity = ınvoices[i].CustomerIdentity,
                    InvoiceTime = ınvoices[i].InvoiceTime,
                    InvoiceDeliveryTime = ınvoices[i].InvoiceDeliveryTime,
                    InvoiceSituation = 1


                });
            }
            return Json("Ödendi");
        }
    }
}
