using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class ChiTietDonHangCF : IEntityTypeConfiguration<ChiTietDonHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietDonHang> builder)
        {
            builder.ToTable("ChiTietDonHang");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.DonHangId, x.SanPhamId });
            builder.Property(x => x.DonGia).HasColumnType("decimal(15,2)");

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.HasOne<SanPham>(x => x.SanPham).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.SanPhamId);
            builder.HasOne<DonHang>(x => x.DonHang).WithMany(x => x.ChiTietDonHangs).HasForeignKey(x => x.DonHangId);
        }
    }
}
