using FluentValidation;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Validations
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Stars).NotEmpty().WithMessage("Yıldız bilgisi girmeyi unutmayınız");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisini unutmayınız");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail bilgisini unutmayınız.");


        }
    }
}
