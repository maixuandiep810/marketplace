using System;
using FluentValidation;

namespace marketplace.DTO.SystemManager.User
{
    public class UpdateUserDTO
    {
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
    }




    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            // RuleFor(x => x.Email).EmailAddress().WithMessage("Email format is not valid.");
            // RuleFor(x => x.FirstName).Length(1, 32);
            // RuleFor(x => x.LastName).Length(1, 32);
        }
    }
}