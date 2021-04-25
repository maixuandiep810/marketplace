using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class BrandInCategory : IBaseEntity<int>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        
        public int BrandId { get; set; }
        public int CategoryId { get; set; }


        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
