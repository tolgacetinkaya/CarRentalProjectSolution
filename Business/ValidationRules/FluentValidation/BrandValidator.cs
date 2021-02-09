using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).Must(name => name.Length > 2).NotEmpty().WithMessage("Araç ismi 2 harften az veya boş olamaz");
            RuleFor(b => b.ModelName).Must(name => name.Length > 2).NotEmpty().WithMessage("Araç ismi 2 harften az veya boş olamaz");
        }
    }
}
