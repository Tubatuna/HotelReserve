using FluentValidation;
using HR.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Bussiness.Validations
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(r => r.RoomType).NotEmpty().WithMessage("Her odanın bir tipi olmalıdır.);");

        }
    }
}
