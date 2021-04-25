using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class ProductInCategory : IBaseEntity<int>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
        public int ProductId { get; set; }
        public int CategoryId { get; set; }


        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
