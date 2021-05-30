using System;
using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class QuyenEntityTaiKhoan : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }
        
        public Guid TaiKhoanId { get; set; }
        public int QuyenEntityId { get; set; }
        public string EntityId { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual QuyenEntity QuyenEntity { get; set; }
    }
}