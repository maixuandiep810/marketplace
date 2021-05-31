using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class CapTinh : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string MaTinh { get; set; }
        public string Ten { get; set; }

        public virtual List<CapHuyen> CapHuyens { get; set; }
    }
}