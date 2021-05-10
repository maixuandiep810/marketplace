using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class ChiTietDanhMuc : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public string Ten { set; get; }
        public string MoTa { set; get; }
        

        public int DanhMucId { set; get; }
        public string NgonNguId { set; get; }


        public virtual DanhMuc DanhMuc { get; set; }
        public virtual NgonNgu NgonNgu { get; set; }

    }
}
