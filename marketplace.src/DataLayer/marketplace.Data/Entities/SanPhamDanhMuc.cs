﻿using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class SanPhamDanhMuc : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }


        public int SanPhamId { get; set; }
        public int DanhMucId { get; set; }


        public virtual SanPham SanPham { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
