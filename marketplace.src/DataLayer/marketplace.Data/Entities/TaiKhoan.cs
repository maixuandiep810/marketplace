using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Identity;

using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public class TaiKhoan : IdentityUser<Guid>, IBaseEntity<Guid>
    {
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }


        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public bool LaNguoiBan { get; set; }


        public virtual KhachHang KhachHang { get; set; }
        public virtual NguoiBan NguoiBan { get; set; }
        // public List<QuyenEntityTaiKhoan> QuyenEntityTaiKhoans { get; set; }
    }
}