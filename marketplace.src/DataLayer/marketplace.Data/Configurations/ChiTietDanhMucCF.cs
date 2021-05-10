using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace.Data.Configurations
{
    public class ChiTietDanhMucCF : IEntityTypeConfiguration<ChiTietDanhMuc>
    {
        public void Configure(EntityTypeBuilder<ChiTietDanhMuc> builder)
        {
            builder.ToTable("DanhMucDichThuat");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.DanhMucId, x.NgonNguId });

            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext");
            builder.Property(x => x.NgonNguId).HasColumnType("varchar(16)").IsRequired();

            builder.HasOne<NgonNgu>(x => x.NgonNgu).WithMany(x => x.ChiTietDanhMucs).HasForeignKey(x => x.NgonNguId);
            builder.HasOne<DanhMuc>(x => x.DanhMuc).WithMany(x => x.ChiTietDanhMucs).HasForeignKey(x => x.DanhMucId);
        }
    }
}
