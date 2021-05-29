using System;
using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class QuyenEntityTaiKhoan : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public Guid TaiKhoanId { get; set; }
        public int QuyenEntityId { get; set; }
        public string EntityId { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual QuyenEntity QuyenEntity { get; set; }
    }
}