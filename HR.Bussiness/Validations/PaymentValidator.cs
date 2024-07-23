using FluentValidation;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Validations
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
         // RuleFor(p => p.PaymentMethod).NotEmpty().WithMessage("Method bilgisini unutmayın");
            RuleFor(p => p.Amount).NotEmpty().WithMessage("Miktar bilgisini unutmayın");
            
        }
    }
}
