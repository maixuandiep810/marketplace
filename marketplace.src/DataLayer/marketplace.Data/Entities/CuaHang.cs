using System.Collections.Generic;
using System;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class CuaHang : IBaseEntity<int>
    {
        public int Id { set; get; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }


        public string MaCH { get; set; }
        public string Ten { get; set; }
        public string TenDayDu { set; get; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }

        public int LangNgheId { get; set; }


        public virtual LangNghe LangNghe { get; set; }
        public virtual List<NguoiBan> NguoiBans { get; set; }
        public virtual List<QuanLyDonHang> QuanLyDonHangs { get; set; }

    }
}