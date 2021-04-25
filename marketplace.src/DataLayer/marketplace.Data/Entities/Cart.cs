using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class Cart : IBaseEntity<int>
    {
        public int Id { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public int UserId { get; set; }
        public int ProductId { set; get; }


        public virtual Product Product { get; set; }
        public virtual CustomerDetail CustomerDetail { get; set; }
    }
}
