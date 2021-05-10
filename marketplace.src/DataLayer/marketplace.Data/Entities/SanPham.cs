using System;
using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class SanPham : IBaseEntity<int>
    {
        public int Id { set; get; }
        public bool DaXoa { get; set; }
        public string MaSP { get; set; }
        public decimal DonGia { set; get; }
        public decimal DonGiaGoc { set; get; }
        public int SoLuong { set; get; }
        public int LuotXem { set; get; }

        public virtual List<SanPhamDanhMuc> SanPhamDanhMucs { get; set; }
        public virtual List<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual List<GioHang> GioHangs { get; set; }
        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}

// public bool? IsFeatured { get; set; }
