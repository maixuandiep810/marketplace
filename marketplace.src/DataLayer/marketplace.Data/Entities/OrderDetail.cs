using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class OrderDetail : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public int OrderId { set; get; }
        public int ProductId { set; get; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
