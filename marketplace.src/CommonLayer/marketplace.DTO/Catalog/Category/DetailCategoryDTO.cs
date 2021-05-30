using FluentValidation;
using marketplace.Data.Entities;

namespace marketplace.DTO.Catalog.Category
{
    public class DetailCategoryDTO
    {
        public int CategoryId { get; set; }
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class DetailCategoryDTOValidator : AbstractValidator<DetailCategoryDTO>
    {
        public DetailCategoryDTOValidator()
        {
            // RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required.")
            //     .Length(4, 32).WithMessage("Code length must be between 4 and 14 characters.");
        }
    }
}
