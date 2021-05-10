using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class ChiTietSanPham : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public string Ten { set; get; }
        public string TenDayDu { set; get; }
        public string MoTa { set; get; }


        public int SanPhamId { set; get; }
        public string NgonNguId { set; get; }


        public virtual SanPham SanPham { get; set; }
        public virtual NgonNgu NgonNgu { get; set; }
    }
}
