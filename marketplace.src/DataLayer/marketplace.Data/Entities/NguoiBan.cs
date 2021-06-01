using System;
using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class NguoiBan : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string MaNB { get; set; }
        public string MoTa { get; set; }
        public Guid TaiKhoanId { set; get; }
        public int CuaHangId { get; set; }


        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual CuaHang CuaHang { get; set; }
        public virtual List<QuanLyDonHang> QuanLyDonHangs { get; set; }
    }
}