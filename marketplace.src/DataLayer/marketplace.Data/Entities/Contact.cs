using vigalileo.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class Contact : IBaseEntity<int>
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public Status Status { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
