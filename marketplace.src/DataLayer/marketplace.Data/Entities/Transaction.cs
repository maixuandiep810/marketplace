using vigalileo.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class Transaction : IBaseEntity<int>
    {
        public int Id { set; get; }
        // public string ExternalTransactionId { set; get; }
        public decimal Amount { set; get; }
        public decimal Fee { set; get; }
        public TransactionStatus Status { set; get; }
        public string Provider { set; get; }
        public string Message { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public int OrderId { get; set; }


        public virtual Order Order { get; set; }

    }
}
