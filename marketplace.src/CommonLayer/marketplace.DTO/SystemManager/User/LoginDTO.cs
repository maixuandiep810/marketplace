using FluentValidation;

namespace marketplace.DTO.SystemManager.User
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public bool RememberMe { get; set; }
    }
    
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
        }
    }
}