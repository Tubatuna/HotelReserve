using FluentValidation;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Validations
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
           
            RuleFor(b => b.TotalPrice).NotEmpty().WithMessage("Fiyat bilgisi girmeyi unutmayınız.");
            RuleFor(b => b.Room).NotNull().WithMessage("Oda bilgisini unutmayınız");
            RuleFor(b => b.ChechOutDate).GreaterThan(b => b.CheckInDate)
                .WithMessage("Çıkış tarihi giriş tarihinden sonra olmalıdır.");
        }
    }
}
