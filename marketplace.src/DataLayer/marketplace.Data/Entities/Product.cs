using System;
using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class Product : IBaseEntity<int>
    {
        public int Id { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual List<ProductInCategory> ProductInCategories { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<ProductTranslation> ProductTranslations { get; set; }
        // public virtual List<ImageInfo> ProductImages { get; set; }



        // public bool? IsFeatured { get; set; }
    }
}