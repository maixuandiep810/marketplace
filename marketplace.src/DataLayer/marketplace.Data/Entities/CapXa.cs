using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class CapXa : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }


        public string Ten { get; set; }

        public int CapHuyenId { get; set; }

        public virtual CapHuyen CapHuyen { get; set; }
        public virtual List<LangNghe> LangNghes { get; set; }
    }
}