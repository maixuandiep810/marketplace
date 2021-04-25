using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class Brand : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual List<BrandInCategory> BrandInCategories { get; set; }
        public virtual List<Store> Stores { get; set; }
    }
}