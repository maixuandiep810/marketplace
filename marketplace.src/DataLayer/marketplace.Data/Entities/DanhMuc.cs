using marketplace.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class DanhMuc : IBaseEntity<int>
    {
        public int Id { set; get; }
        public string MaSo { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }

        public string Ten { set; get; }
        public string MoTa { set; get; }

        public virtual List<SanPhamDanhMuc> SanPhamDanhMucs { get; set; }
    }
}


// public int? ParentId { set; get; }
// 