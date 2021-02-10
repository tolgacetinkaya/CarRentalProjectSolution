﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük kira bedeli 0'dan büyük olmalıdır.").NotEmpty();
            RuleFor(c => c.ModelName).Must(name => name.Length > 2).NotEmpty().WithMessage("Araç ismi 2 harften az veya boş olamaz");
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
        }
    }
}
