using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace.Data.Configurations
{
    public class SanPhamCF : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable("SanPham");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaSP).HasColumnType("nvarchar(32)").IsRequired();
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.TenDayDu).HasColumnType("nvarchar(1024)").IsRequired();
            builder.Property(x => x.DonGia).HasColumnType("decimal(10,8)");
            builder.Property(x => x.DonGiaGoc).HasColumnType("decimal(10,8)").IsRequired();
            builder.Property(x => x.SoLuong).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.LuotXem).IsRequired().HasDefaultValue(0);
        }
    }
}
