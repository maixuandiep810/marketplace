using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class HinhAnh
    {
        public int Id { get; set; }
        public string MaHA { get; set; }
        public string MoTa { get; set; }
        public string Url { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public string DoiTuongId { get; set; }
        public string Loai { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
    }
}
