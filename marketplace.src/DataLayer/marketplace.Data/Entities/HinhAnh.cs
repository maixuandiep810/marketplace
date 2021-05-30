using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class HinhAnh : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }
        
        public string MaHA { get; set; }
        public string MoTa { get; set; }
        public string Url { get; set; }
        public string TieuDe { get; set; }
        public bool LaAnhMacDinh { get; set; }
        public string DoiTuongId { get; set; }
        public string Loai { get; set; }
        public int ThuTu { get; set; }
        // public long KichThuocFile { get; set; }
    }
}
