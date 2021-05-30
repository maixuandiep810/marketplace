﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class VaiTro : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string MoTa { get; set; }

        public List<QuyenEntityVaiTro> QuyenEntityVaiTros { get; set; }
        public List<QuyenRouteVaiTro> QuyenRouteVaiTros { get; set; }
    }
}
