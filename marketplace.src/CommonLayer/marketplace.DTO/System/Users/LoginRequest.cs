using FluentValidation;

namespace marketplace.DTOs.System.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        // public bool RememberMe { get; set; }
    }
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).Length(4, 32).WithMessage("Username length must be between 4 and 14 characters.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password length must be at least 8.")
                .MaximumLength(16).WithMessage("Password length must not exceed 16.");
        }
    }
}