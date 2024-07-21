using FluentValidation;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Validations
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Soyad bilgisi girmeyi unutmayınız.");
            RuleFor(s => s.Phone).Length(11).WithMessage("Telefon numarası 11 haneli olmalıdır.");
            RuleFor(s => s.Position).NotEmpty().WithMessage("Pozisyon bilgisi girmeyi unutmayınız");
            RuleFor(s => s.Hotel).NotNull().WithMessage("Otel bilgisi eklemeyi unutmayınız.");
        }
    }
}
