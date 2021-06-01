using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class CapHuyen : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string Ten { get; set; }

        public int CapTinhId { get; set; }

        public virtual CapTinh CapTinh { get; set; }
        public virtual List<CapXa> CapXas { get; set; }
    }
}