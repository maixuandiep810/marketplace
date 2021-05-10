using System;
using marketplace.Data.Entities;

namespace marketplace.DTO.SystemManager.User
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
    }
}