using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class QuyenEntityCF : IEntityTypeConfiguration<QuyenEntity>
    {
        public void Configure(EntityTypeBuilder<QuyenEntity> builder)
        {
            builder.ToTable("QuyenEntity");

            builder.HasKey(x => x.Id);
            // builder.HasAlternateKey(x => new { x.HanhDong, x.TenEntity, x.BitFields });

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.Ten).HasColumnType("varchar(256)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.TenEntity).HasColumnType("varchar(256)").IsRequired();
            builder.Property(x => x.HanhDong).HasColumnType("varchar(256)").IsRequired(true);
            builder.Property(x => x.BitFields).IsRequired(true).HasDefaultValue(0);
        }
    }
}
