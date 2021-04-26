using System;
using marketplace.Data.Entities;
using vigalileo.DTOs.System.Users;

namespace marketplace.DTOs.System.Users
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool LaNguoiBan { get; set; }

        public UserDTO(TaiKhoan user)
        {
            Id = user.Id.ToString();
            Username = user.UserName;
            HoTen = user.HoTen;
            NgaySinh = user.NgaySinh;
            LaNguoiBan = user.LaNguoiBan;
        }

        public static TaiKhoan GetTaiKhoan(RegisterRequest request)
        {
            var taiKhoan = new TaiKhoan()
            {
                Email = request.Email,
                UserName = request.UserName,
                HoTen = request.HoTen
            };
            return taiKhoan;
        }
    }
}