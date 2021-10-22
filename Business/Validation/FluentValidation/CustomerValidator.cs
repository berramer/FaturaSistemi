using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(c => c.customerIdentity).NotEmpty().WithMessage("Tc Kimlik Numarası Boş Olamaz");
            RuleFor(c => c.customerName).MaximumLength(50);
            RuleFor(c => c.customerLastName).MaximumLength(50);
            RuleFor(c => c.customerAddress).MaximumLength(50);
            RuleFor(c => c.password).MaximumLength(10);


           // Customer name berra olunca ıd nin 10 dan buyuk olmasını sağlar
            RuleFor(c => c.customerId).GreaterThan(10).When(c => c.customerName == "berra");
            RuleFor(c => c.customerName).EmailAddress();

           // kendimiz bir kural yazmak için
                RuleFor(c => c.customerName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith('A');
        }
    }
    }

