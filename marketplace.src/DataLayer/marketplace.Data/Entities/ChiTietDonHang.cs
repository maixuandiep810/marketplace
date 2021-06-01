using System;
using System.Collections.Generic;
using System.Text;

using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class ChiTietDonHang : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public int SoLuong { set; get; }
        public decimal DonGia { set; get; }
        public int DonHangId { set; get; }
        public int SanPhamId { set; get; }


        public virtual DonHang DonHang { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
