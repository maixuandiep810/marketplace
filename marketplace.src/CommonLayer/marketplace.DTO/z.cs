// using FluentValidation;
// using marketplace.Data.Entities;

// namespace marketplace.DTO.SystemManager.RBAC
// {
//     public class PermissionDTO
//     {
        
//     }

//         public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
//     {
//         public RegisterDTOValidator()
//         {
//             RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.")
//                 .Length(4, 32).WithMessage("Username length must be between 4 and 14 characters.");
//         }
// }