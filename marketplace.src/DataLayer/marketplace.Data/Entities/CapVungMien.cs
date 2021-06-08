using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class CapVungMien : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }
        public int SoCuaHang { get; set; }



        public string Ten { get; set; }

        public virtual List<CapTinh> CapTinhs { get; set; }
    }
}