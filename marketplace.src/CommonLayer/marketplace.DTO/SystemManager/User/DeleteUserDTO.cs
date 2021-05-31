using FluentValidation;

namespace marketplace.DTO.SystemManager.User
{
    public class DeleteUserDTO
    {
        public string UserName { get; set; }
    }

    public class DeleteUserDTOValidator : AbstractValidator<DeleteUserDTO>
    {
        public DeleteUserDTOValidator()
        {
            // RuleFor(x => x.UserName).Length(4, 32).WithMessage("Username length must be between 4 and 14 characters.");
        }
    }
}