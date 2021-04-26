using FluentValidation;

namespace marketplace.DTOs.System.Users
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string HoTen { get; set; }
    }

    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.UserName).Length(4, 32).WithMessage("Username length must be between 4 and 14 characters.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email format is not valid.");
            RuleFor(x => x.HoTen).Length(1, 128);
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