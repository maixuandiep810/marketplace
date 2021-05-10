using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class QuanLyDonHang : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }


        public int CuaHangId { get; set; }
        public int DonHangId { get; set; }
        public int? NguoiBanId { get; set; }


        public virtual CuaHang CuaHang { get; set; }
        public virtual DonHang DonHang { get; set; }
        public virtual ChiTietDonHang ChiTietDonHang { get; set; }
        public virtual NguoiBan NguoiBan { get; set; }
    }
}
