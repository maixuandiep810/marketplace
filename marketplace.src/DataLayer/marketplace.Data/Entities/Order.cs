using vigalileo.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class Order : IBaseEntity<int>
    {
        public int Id { set; get; }
        // public string ShipName { set; get; }
        // public string ShipAddress { set; get; }
        // public string ShipEmail { set; get; }
        // public string ShipPhoneNumber { set; get; }
        public decimal Amount { get; set; }
        public OrderStatus Status { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public int CustomerDetailId { set; get; }


        public virtual CustomerDetail CustomerDetail { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<StoreInOrder> StoreInOrders { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
