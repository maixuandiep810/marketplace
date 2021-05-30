using System;
using marketplace.Data.Enums;
namespace marketplace.Data.Entities
{
    public class QuyenEntityVaiTro : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public TrangThai TrangThai { set; get; }
        
        public int QuyenEntityId { get; set; }
        public Guid VaiTroId { get; set; }

        public virtual VaiTro VaiTro { get; set; }
        public virtual QuyenEntity QuyenEntity { get; set; }
    }
}