using System;
using marketplace.Data.Entities;
using marketplace.DTO.Common;

namespace marketplace.DTO.SystemManager.User
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public bool IsSeller { get; set; }
        public ImageDTO ImageDTO { get; set; }
        public string JwtToken { get; set; }

        public UserDTO()
        {
            JwtToken = "";
        }

        public UserDTO(TaiKhoan user) : this()
        {
            if (user != null)
            {
                Id = user.Id.ToString();
                Username = user.UserName;
                Email = user.Email;
                FullName = user.HoTen;
                Dob = user.NgaySinh;
                IsSeller = user.LaNguoiBan;
            }
        }
    }
}