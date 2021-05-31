using FluentValidation;
using marketplace.Data.Entities;

namespace marketplace.DTO.SystemManager.User
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.")
                .Length(4, 32).WithMessage("Username length must be between 4 and 14 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email format is not valid.");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full Name is required.")
                .Length(4, 128).WithMessage("Full Name length must be between 4 and 14 characters."); ;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password length must be at least 8.")
                .MaximumLength(16).WithMessage("Password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one (!? *.).");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}