using System;
using marketplace.Data.Entities;
using marketplace.DTO.Common;

namespace marketplace.DTO.SystemManager.User
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool LaNguoiBan { get; set; }
        public ImageDTO ImageDTO { get; set; }

        public UserDTO()
        {
            
        }

        public UserDTO(TaiKhoan user) : this()
        {
            if (user != null)
            {
                Id = user.Id.ToString();
                Username = user.UserName;
                HoTen = user.HoTen;
                NgaySinh = user.NgaySinh;
                LaNguoiBan = user.LaNguoiBan;
            }
        }
    }
}