using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class GioHang : IBaseEntity<int>
    {
        public int Id { set; get; }
        public int SoLuong { set; get; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }


        public int KhachHangId { get; set; }
        public int SanPhamId { set; get; }


        public virtual SanPham SanPham { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}
