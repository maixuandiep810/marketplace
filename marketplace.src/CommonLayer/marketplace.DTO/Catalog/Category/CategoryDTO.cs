using System.Collections.Generic;
using FluentValidation;
using marketplace.DTO.Enum;

namespace marketplace.DTO.Catalog.Category
{
    public class CategoryDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}