using Microsoft.AspNetCore.Http;

namespace marketplace.DTO.Catalog.Category
{
    public class CreateCategoryJsonDTO
    {
        public IFormFile Categories { get; set; }
    }
}