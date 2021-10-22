using DataAcces.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using System.Linq;
using System.Text;
using Business.Validation.FluentValidation;
using FluentValidation;

namespace Business
{
    public class CustomerManager
    {
        private CustomerDal _customerDal;

       public  CustomerManager(CustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        public string kullanıcıKontrol(string identity,string password)
        {
          List<Customer> kullanıcı= _customerDal.getAll(x => x.customerIdentity == identity);
            if (kullanıcı.Count() == 0)
            {
                return "Kullanıcı Bulunamadı";
            }
            else
            {
                if (kullanıcı[0].password.Equals(password))
                {

              
                    return "Giriş Başarılı";
                }
                else
                {
                    return "Şifre Yanlış";
                }
            }
        }
        public string sifreyenile(string identity, string password)
        {
            Customer  kullanıcı = _customerDal.getAll(x => x.customerIdentity == identity).FirstOrDefault();
            if (kullanıcı==null)
            {
                return "Kullanıcı Bulunamadı";
            }
            else
            {
                kullanıcı.password = password;
                _customerDal.Update(kullanıcı);
                return "Şifreniz Kaydedildi";
            }
        }
        public Customer profil(string identity)
        {
            Customer kullanıcı = _customerDal.getAll(x => x.customerIdentity == identity).FirstOrDefault();
            if (kullanıcı == null)
            {
                return null;
            }
            else
            {
                return kullanıcı;
            }
        }
        public void kisi_ekle(Customer customer)
        {
             /* bu kodu Validation Tool a taşıyabiliriz*/
            CustomerValidator customerValidator = new CustomerValidator();
            var result = customerValidator.Validate(customer);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }

            Customer customer1 = _customerDal.getAll(x => x.customerIdentity == customer.customerIdentity).FirstOrDefault();
            if (customer1 == null)
            {

                _customerDal.Add(customer);
            }
            else
            {
                if (customer.customerName.Equals(customer1.customerName) && customer.customerLastName.Equals(customer1.customerLastName))
                {
                    customer.customerId = customer1.customerId;
                    _customerDal.Update(customer);
                }
                else
                {
                    throw new Exception("Müşteri Tc si kayıtlı");
                }
            }

          
        }
    }
}
