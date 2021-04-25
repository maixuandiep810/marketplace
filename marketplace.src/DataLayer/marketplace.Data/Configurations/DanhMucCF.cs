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

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaSo).HasColumnType("nvarchar(32)");
            builder.Property(x => x.HienThiTrangChu).HasDefaultValue(true);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.HoatDong);
        }
    }
}
