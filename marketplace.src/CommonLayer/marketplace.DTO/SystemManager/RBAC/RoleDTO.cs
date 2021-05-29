using System.IO;
using FluentValidation;
using marketplace.Data.Entities;

namespace marketplace.DTO.SystemManager.RBAC
{
    public class RoleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RoleDTO(VaiTro vaiTro)
        {
            Id = vaiTro.Id.ToString();
            Name = vaiTro.Name;
            Description = vaiTro.MoTa;
        }
    }
}