namespace marketplace.Data.Entities
{
    public interface IBaseEntity<TPKey>
    {
        TPKey Id { get; set; }
        bool DaXoa { get; set; }
    }
}