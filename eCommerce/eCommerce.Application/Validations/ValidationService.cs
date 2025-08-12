﻿using eCommerce.Application.DTOs;
using FluentValidation;

namespace eCommerce.Application.Validations
{
    public class ValidationService : IValidationService
    {
        public async Task<ServiceResponse> ValidateAsync<T>(T model, IValidator<T> validator)
        {
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                string errorToString = string.Join(", ", errors);
                return new ServiceResponse { Message = errorToString };
            }
            return new ServiceResponse { Success = true };
        }
    }
}
