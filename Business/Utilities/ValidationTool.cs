using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities
{
    public class ValidationTool
    {
        public static void Validate<T>(IValidator<T> validator, T entity)
        {
            var validationResult = validator.Validate(entity);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

    }
}
