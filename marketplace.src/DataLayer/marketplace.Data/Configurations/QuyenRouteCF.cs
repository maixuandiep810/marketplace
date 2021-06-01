using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class QuyenRouteCF : IEntityTypeConfiguration<QuyenRoute>
    {
        public void Configure(EntityTypeBuilder<QuyenRoute> builder)
        {
            builder.ToTable("QuyenRoute");

            builder.HasKey(x => x.Id);
            // builder.HasAlternateKey(x => new { x.HanhDong, x.Ten });

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Ten).HasColumnType("varchar(256)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.HanhDong).HasColumnType("varchar(256)").IsRequired(true);
            builder.Property(x => x.PathRegex).HasColumnType("ntext").IsRequired(true);
        }
    }
}
