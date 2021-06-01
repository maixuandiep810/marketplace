using marketplace.Data.Entities;
using marketplace.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace.Data.Configurations
{
    public class DanhMucCF : IEntityTypeConfiguration<DanhMuc>
    {
        public void Configure(EntityTypeBuilder<DanhMuc> builder)
        {
            builder.ToTable("DanhMuc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext");
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.HoatDong);
        }
    }
}
