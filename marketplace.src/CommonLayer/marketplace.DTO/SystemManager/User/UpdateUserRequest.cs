using FluentValidation;

namespace vigalileo.DTO.System.Users
{
    public class UpdateUserDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email format is not valid.");
            RuleFor(x => x.FirstName).Length(1, 32);
            RuleFor(x => x.LastName).Length(1, 32);
        }
    }
}