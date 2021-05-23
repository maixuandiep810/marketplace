using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace marketplace.DTO.Common
{
    public class CreateImagesDTO
    {
        public List<IFormFile> FormImages { get; set; }
    }

    public class CreateImagesDTOValidator : AbstractValidator<CreateImagesDTO>
    {
        public CreateImagesDTOValidator()
        {
        }
    }
}   