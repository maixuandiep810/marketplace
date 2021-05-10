using System;
using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class KhachHang : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public Guid TaiKhoanId { set; get; }

        
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual List<GioHang> GioHangs { get; set; }
        public virtual List<DonHang> DonHangs { get; set; }
        public virtual List<GiaoDich> GiaoDichs { get; set; }
    }
}