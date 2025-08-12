using eCommerce.Application.DTOs.Identity;
using FluentValidation;

namespace eCommerce.Application.Validations.Authentication
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("Fullname is required!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Invalid email");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain atleast one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain atleast one lowercase letter")
                .Matches(@"\d").WithMessage("Password must contain atleast one number")
                .Matches(@"[^\w]").WithMessage("Password must contain atleast one special character");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword is required!")
                .Equal(x => x.Password).WithMessage("ConfirmPassword doesn't match password");
        }
    }
}
