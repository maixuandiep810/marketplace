using marketplace.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class DonHang : IBaseEntity<int>
    {
        public int Id { set; get; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string MoTa { get; set; }
        public decimal ThanhTien { get; set; }
        public TrangThaiDonHang TrangThaiDonHang { set; get; }
        public int NguoiMuaId { set; get; }
        public int CuaHangId { set; get; }


        public virtual NguoiMua NguoiMua { get; set; }
        public virtual CuaHang CuaHang { get; set; }
        public virtual List<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}


// public string ShipName { set; get; }
// public string ShipAddress { set; get; }
// public string ShipEmail { set; get; }
// public string ShipPhoneNumber { set; get; }