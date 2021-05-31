using System.ComponentModel;
using System.Collections.Generic;
using FluentValidation;
using marketplace.Data.Entities;
using marketplace.Data.Enums;
using marketplace.DTO.Enum;
using marketplace.DTO.Common;

namespace marketplace.DTO.Catalog.Branch
{
    public class CreateBranchDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int CommuneId { get; set; }
    }

    public class CreateBranchDTOValidator : AbstractValidator<CreateBranchDTO>
    {
        public CreateBranchDTOValidator()
        {
            // RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.")
            //     .Length(4, 32).WithMessage("Code length must be between 4 and 14 characters.");
        }
    }
}