using System;
namespace marketplace.Data.Entities
{
    public class QuyenRouteVaiTro : IBaseEntity<int>
    {
        public int Id { get; set; }
        public bool DaXoa { get; set; }
        public int QuyenRouteId { get; set; }
        public Guid VaiTroId { get; set; }

        public virtual VaiTro VaiTro { get; set; }
        public virtual QuyenRoute QuyenRoute{ get; set; }
    }
}