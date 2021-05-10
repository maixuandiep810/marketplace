using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class NgonNgu : IBaseEntity<string>
    {
        public string Id { get; set; }
        public bool DaXoa { get; set; }
        public string MaNN { get; set; }
        public string Ten { get; set; }
        public bool MacDinh { get; set; }


        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public virtual List<ChiTietDanhMuc> ChiTietDanhMucs { get; set; }
    }
}
