using marketplace.Data.Enums;

namespace marketplace.Data.Entities
{
    public interface IBaseEntity<TPKey>
    {
        TPKey Id { get; set; }
        string MaSo { get; set; }
        bool DaXoa { get; set; }
        TrangThai TrangThai { set; get; }
    }
}