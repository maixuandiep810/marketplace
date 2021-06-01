﻿using marketplace.Data.Enums;
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
        public int KhachHangId { set; get; }


        public virtual KhachHang KhachHang { get; set; }
        public virtual List<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual List<QuanLyDonHang> QuanLyDonHangs { get; set; }
        public virtual GiaoDich GiaoDich { get; set; }
    }
}


// public string ShipName { set; get; }
// public string ShipAddress { set; get; }
// public string ShipEmail { set; get; }
// public string ShipPhoneNumber { set; get; }