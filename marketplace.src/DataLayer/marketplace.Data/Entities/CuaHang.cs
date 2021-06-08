using System.Collections.Generic;
using System;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class CuaHang : IBaseEntity<int>
    {
        public int Id { set; get; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string Ten { get; set; }

        public string TenDayDu { set; get; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }

        public int LangNgheId { get; set; }
        public int NguoiBanId { get; set; }


        public virtual List<DonHang> DonHangs { get; set; }
        public virtual LangNghe LangNghe { get; set; }
        public virtual NguoiBan NguoiBan { get; set; }
    }
}