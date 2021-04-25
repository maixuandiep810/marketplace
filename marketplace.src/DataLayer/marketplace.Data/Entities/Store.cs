using System.Collections.Generic;
using System;
namespace marketplace.Data.Entities
{
    public class Store : IBaseEntity<int>
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Description { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public int BrandId { get; set; }


        public virtual Brand Brand { get; set; }
        public virtual List<SellerDetail> SellerDetails { get; set; }
        public virtual List<StoreInOrder> StoreInOrders { get; set; }

    }
}