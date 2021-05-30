using System.Collections.Generic;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class QuyenRoute : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }
        
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string HanhDong { get; set; }
        public string PathRegex { get; set; }
        public bool LaRouteCanXacThuc { get; set; }

        public List<QuyenRouteVaiTro> QuyenRouteVaiTros { get; set; }
    }
}