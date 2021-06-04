using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class CapTinh : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }


        public string Ten { get; set; }
        public string TenUrl { get; set; }
        public string TenUrlDayDu { get; set; }
        public int SoCuaHang { get; set; }


        public int CapVungMienId { get; set; }



        public CapVungMien CapVungMien { get; set; }
        public virtual List<CapHuyen> CapHuyens { get; set; }
    }
}