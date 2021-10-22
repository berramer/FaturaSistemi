using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
  public   class SystemUserValidator: AbstractValidator<SystemUser>
    {
        public SystemUserValidator()
        {
            RuleFor(s => s.SystemUserName).NotEmpty().WithMessage("Kullanıcı Adı boş olamaz");
            RuleFor(s => s.Password).NotEmpty();
            RuleFor(s => s.Password).MaximumLength(10);
            RuleFor(s => s.email).EmailAddress();

        }
    }
}
