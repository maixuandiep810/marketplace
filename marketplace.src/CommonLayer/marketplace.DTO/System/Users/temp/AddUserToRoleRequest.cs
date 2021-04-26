using System;
using FluentValidation;

namespace vigalileo.DTOs.System.Users
{
    public class AddUserToRoleRequest
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class AddUserToRoleRequestValidator : AbstractValidator<AddUserToRoleRequest>
    {
        public AddUserToRoleRequestValidator()
        {
        }
    }
}