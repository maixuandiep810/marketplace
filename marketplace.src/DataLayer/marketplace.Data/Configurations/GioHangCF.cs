using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class GioHangCF : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.ToTable("GioHang");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);
            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");

            builder.HasOne<SanPham>(x => x.SanPham).WithMany(x => x.GioHangs).HasForeignKey(x => x.SanPhamId);
            builder.HasOne<KhachHang>(x => x.KhachHang).WithMany(x => x.GioHangs).HasForeignKey(x => x.KhachHangId);
        }
    }
}
