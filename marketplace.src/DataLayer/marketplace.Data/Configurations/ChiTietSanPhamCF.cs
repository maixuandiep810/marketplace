using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Configurations
{
    public class ChiTietSanPhamCF : IEntityTypeConfiguration<ChiTietSanPham>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham> builder)
        {
            builder.ToTable("ChiTietSanPham");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.SanPhamId, x.NgonNguId });

            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.TenDayDu).HasColumnType("nvarchar(1024)");
            builder.Property(x => x.MoTa).HasColumnType("ntext");
            builder.Property(x => x.NgonNguId).HasColumnType("varchar(16)").IsRequired();

            builder.HasOne<NgonNgu>(x => x.NgonNgu).WithMany(x => x.ChiTietSanPhams).HasForeignKey(x => x.NgonNguId);
            builder.HasOne<SanPham>(x => x.SanPham).WithMany(x => x.ChiTietSanPhams).HasForeignKey(x => x.SanPhamId);

        }
    }
}
