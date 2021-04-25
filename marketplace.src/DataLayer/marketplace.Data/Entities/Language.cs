using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class Language : IBaseEntity<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }


        public virtual List<ProductTranslation> ProductTranslations { get; set; }
        public virtual List<CategoryTranslation> CategoryTranslations   { get; set; }
    }
}
