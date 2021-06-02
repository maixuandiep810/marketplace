using marketplace.Data.Entities;
using marketplace.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace.Data.Configurations
{
    public class LangNgheCF : IEntityTypeConfiguration<LangNghe>
    {
        public void Configure(EntityTypeBuilder<LangNghe> builder)
        {
            builder.ToTable("LangNghe");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);


            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)");
            builder.Property(x => x.TenDayDu).HasColumnType("ntext");
            builder.Property(x => x.MoTa).HasColumnType("ntext");
            builder.Property(x => x.DiaChi).HasColumnType("ntext");
        }
    }
}
