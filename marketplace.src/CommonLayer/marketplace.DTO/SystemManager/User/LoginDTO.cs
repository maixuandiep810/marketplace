using FluentValidation;

namespace marketplace.DTO.SystemManager.User
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            // RuleFor(x => x.UserName).Length(4, 32).WithMessage("Username length must be between 4 and 14 characters.");
            // RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            //     .MinimumLength(8).WithMessage("Password length must be at least 8.")
            //     .MaximumLength(16).WithMessage("Password length must not exceed 16.");
        }
    }
}