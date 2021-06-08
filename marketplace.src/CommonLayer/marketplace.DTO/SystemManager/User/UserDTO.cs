using System;
using marketplace.Data.Entities;
using marketplace.DTO.Common;

namespace marketplace.DTO.SystemManager.User
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string RoleName { get; set; }
        public string RoleNames { get; set; }
        public ImageDTO ImageDTO { get; set; }
        public string JwtToken { get; set; }

        public UserDTO()
        {
            JwtToken = "";
        }

        public UserDTO(TaiKhoan user) : this()
        {
            Id = user.Id.ToString();
            UserName = user.UserName;
            Email = user.Email;
            FullName = user.HoTen;
            Dob = user.NgaySinh;
        }
    }
}