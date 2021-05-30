using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class SanPhamDanhMucCF : IEntityTypeConfiguration<SanPhamDanhMuc>
    {
        public void Configure(EntityTypeBuilder<SanPhamDanhMuc> builder)
        {
            builder.ToTable("SanPhamDanhMuc");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.DanhMucId, x.SanPhamId });

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.HasOne<SanPham>(x => x.SanPham).WithMany(x => x.SanPhamDanhMucs)
                .HasForeignKey(x => x.SanPhamId);
            builder.HasOne<DanhMuc>(x => x.DanhMuc).WithMany(x => x.SanPhamDanhMucs)
              .HasForeignKey(x => x.DanhMucId);
        }
    }
}
