using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class GioHang : IBaseEntity<int>
    {
        public int Id { set; get; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public int SoLuong { set; get; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }


        public int NguoiMuaId { get; set; }
        public int SanPhamId { set; get; }


        public virtual SanPham SanPham { get; set; }
        public virtual NguoiMua NguoiMua { get; set; }
    }
}
