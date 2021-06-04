using System.Collections.Generic;
using marketplace.Data.Enums;
namespace marketplace.Data.Entities
{
    public class LangNghe : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string Ten { get; set; }
        public string TenUrl { get; set; }
        public string TenUrlDayDu { get; set; }

        public string TenDayDu { get; set; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }
        public int SoCuaHang { get; set; }



        public int CapHuyenId { get; set; }



        public virtual CapHuyen CapHuyen { get; set; }
        public virtual List<LangNgheDanhMuc> LangNgheDanhMucs { get; set; }
        public virtual List<CuaHang> CuaHangs { get; set; }
    }
}