using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class SanPhamCF : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.TenDayDu).HasColumnType("ntext");
            builder.Property(x => x.MoTa).HasColumnType("ntext");
            builder.Property(x => x.DonGia).HasColumnType("decimal(15,2)");
            builder.Property(x => x.DonGiaGoc).HasColumnType("decimal(15,2)").IsRequired();
            builder.Property(x => x.SoLuong).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.LuotXem).IsRequired().HasDefaultValue(0);
        }
    }
}
