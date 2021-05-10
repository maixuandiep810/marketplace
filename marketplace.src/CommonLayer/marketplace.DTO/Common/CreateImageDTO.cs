using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace marketplace.DTO.Common
{
    public class CreateImageDTO
    {
        public IFormFile FormImage { get; set; }
        public bool IsDefault { get; set; }
    }

    public class CreateImageDTOValidator : AbstractValidator<CreateImageDTO>
    {
        public CreateImageDTOValidator()
        {
        }
    }
}   