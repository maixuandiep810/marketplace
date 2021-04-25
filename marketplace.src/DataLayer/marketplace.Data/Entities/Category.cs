using vigalileo.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class Category : IBaseEntity<int>
    {
        public int Id { set; get; }
        public bool IsShowOnHome { set; get; }
        public Status Status { set; get; }


        public int? ParentId { set; get; }


        public virtual List<ProductInCategory> ProductInCategories { get; set; }
        public virtual List<BrandInCategory> BrandInCategories { get; set; }
        public virtual List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
