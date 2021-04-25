using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class NgonNgu : IBaseEntity<string>
    {
        public string Id { get; set; }
        public string MaNN { get; set; }
        public string Ten { get; set; }
        public bool MacDinh { get; set; }


        public virtual List<SanPhamDichThuat> SanPhamDichThuats { get; set; }
        public virtual List<DanhMucDichThuat> DanhMucDichThuats { get; set; }
    }
}
