using FluentValidation;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Validations
{
    public class GuestValidator : AbstractValidator<Guest>
    {
        public GuestValidator()
        {
            RuleFor(g => g.FirstName).NotEmpty().WithMessage("İsim bilgisini eklemeyi unutmayınız.");
            RuleFor(g => g.LastName).NotEmpty().WithMessage("Soyad bilgisini unutmayınız.");
            RuleFor(g => g.Phone).Length(11).NotEmpty().WithMessage("Telefon bilgisi 11 haneli olmalıdır.");
            RuleFor(g => g.Address).NotEmpty().WithMessage("Adres bilgisini eklemeyi unutmayınız.");
            RuleFor(g => g.Email).NotEmpty().WithMessage("Mail bilgisini eklemeyi unutmayınız.");

        }
    }
}
