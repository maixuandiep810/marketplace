using marketplace.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Entities
{
    public class GiaoDich : IBaseEntity<int>
    {
        public int Id { set; get; }
        public bool DaXoa { get; set; }

        public string MaGD { get; set; }
        public decimal ThanhTien { set; get; }
        public decimal Phi { set; get; }
        public TrangThaiGiaoDich TrangThai { set; get; }
        public string NhaCungCap { set; get; }
        public string LoiNhan { set; get; }

        public int DonHangId { get; set; }


        public virtual DonHang DonHang { get; set; }

    }
}
