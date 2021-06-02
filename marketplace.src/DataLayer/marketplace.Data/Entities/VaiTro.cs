using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class VaiTro : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string NhomVT { get; set; }
        public string MoTa { get; set; }

        public List<QuyenRouteVaiTro> QuyenRouteVaiTros { get; set; }
    }
}
