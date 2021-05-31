using System.Collections.Generic;
using marketplace.Data.Enums;
namespace marketplace.Data.Entities
{
    public class LangNghe : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string MaLN { get; set; }
        public string Ten { get; set; }
        public string TenDayDu { get; set; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }
        public int CapXaId { get; set; }


        
        public virtual CapXa CapXa { get; set; }
        public virtual List<LangNgheDanhMuc> LangNgheDanhMucs { get; set; }
        public virtual List<CuaHang> CuaHangs { get; set; }
    }
}