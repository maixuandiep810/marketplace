using System;
using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class NguoiMua : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public Guid TaiKhoanId { set; get; }

        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual List<GioHang> GioHangs { get; set; }
        public virtual List<DonHang> DonHangs { get; set; }
    }
}