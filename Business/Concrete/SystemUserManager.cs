using Business.Validation.FluentValidation;
using DataAcces.Concrete;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class SystemUserManager
    {

        private SystemUserDal _systemUserDal { get; set; }

        public SystemUserManager(SystemUserDal systemUserDal)
        {
            _systemUserDal = systemUserDal;
        }

        public string kullanıcıKontrol(string kulad, string password)
        {
            List<SystemUser> kullanıcı = _systemUserDal.getAll(x => x.SystemUserName == kulad);
            if (kullanıcı.Count() == 0)
            {
                return "Kullanıcı Bulunamadı";
            }
            else
            {
                if (kullanıcı[0].Password.Equals(password))
                {
                    return "Giriş Başarılı";
                }
                else
                {
                    return "Şifre Yanlış";
                }
            }
        }


        public void adminekle(SystemUser systemUser)
        {

            SystemUserValidator system = new SystemUserValidator();
          var result =  system.Validate(systemUser);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }

            _systemUserDal.Add(systemUser);

        }
    }
}

