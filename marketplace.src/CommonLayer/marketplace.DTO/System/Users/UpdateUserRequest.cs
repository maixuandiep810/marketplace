using FluentValidation;

namespace vigalileo.DTOs.System.Users
{
    public class UpdateUserRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email format is not valid.");
            RuleFor(x => x.FirstName).Length(1, 32);
            RuleFor(x => x.LastName).Length(1, 32);
        }
    }
}