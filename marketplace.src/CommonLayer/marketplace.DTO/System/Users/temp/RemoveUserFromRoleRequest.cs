using System;
using FluentValidation;

namespace vigalileo.DTOs.System.Users
{
    public class RemoveUserFromRoleRequest
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class RemoveUserFromRoleRequestValidator : AbstractValidator<RemoveUserFromRoleRequest>
    {
        public RemoveUserFromRoleRequestValidator()
        {
        }
    }
}