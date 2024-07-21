using FluentValidation;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Validations
{
    public class RoomTypeValidator : AbstractValidator<RoomType>
    {
        public RoomTypeValidator()
        {
            RuleFor(r=>r.Name).NotEmpty();
            RuleFor(r => r.Capacity).NotEmpty().WithMessage("Kapasite bilgisi girmeyi unutmayın.");
            RuleFor(r => r.PricePerNight).NotEmpty().WithMessage("Fiyat bilgisi girmeyi unutmayınız");

        }
    }
}
