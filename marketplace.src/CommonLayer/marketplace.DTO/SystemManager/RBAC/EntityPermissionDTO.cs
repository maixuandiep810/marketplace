using FluentValidation;
using marketplace.Data.Entities;

namespace marketplace.DTO.SystemManager.RBAC
{
    public class EntityPermissionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EntityName { get; set; }
        public string Action { get; set; }
        public int BitFields { get; set; }

        public EntityPermissionDTO(QuyenEntity quyenEntity)
        {
            Id = quyenEntity.Id;
            Name = quyenEntity.Ten;
            EntityName = quyenEntity.TenEntity;
            Action = quyenEntity.HanhDong;
            BitFields = quyenEntity.BitFields;
        }
    }
}