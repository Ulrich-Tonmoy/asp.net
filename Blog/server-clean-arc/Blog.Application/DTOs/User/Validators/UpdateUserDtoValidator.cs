﻿using Blog.Application.IRepository;
using FluentValidation;

namespace Blog.Application.DTOs.UserValidators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator(IUserRepository userRepository)
        {
            RuleFor(l => l.Name).NotNull();
            RuleFor(l => l.Password).NotNull().MinimumLength(6);
            RuleFor(l => l.Email).MustAsync(async (email, token) =>
            {
                var exist = await userRepository.Exists(u => u.Email.Equals(email));
                return !exist;
            });
        }
    }
}
