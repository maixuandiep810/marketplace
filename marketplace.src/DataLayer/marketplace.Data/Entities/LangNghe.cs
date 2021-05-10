using System.Collections.Generic;

namespace marketplace.Data.Entities
{
    public class LangNghe : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public string MaLN { get; set; }
        public string Ten { get; set; }
        public string TenDayDu { get; set; }
        public string MoTa { get; set; }


        public virtual List<LangNgheDanhMuc> LangNgheDanhMucs { get; set; }
        public virtual List<CuaHang> CuaHangs { get; set; }
    }
}