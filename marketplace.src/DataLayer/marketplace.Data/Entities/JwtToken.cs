using System;
using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class JwtToken : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string Token { get; set; }

        public Guid TaiKhoanId { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}