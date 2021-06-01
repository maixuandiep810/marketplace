using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class QuanLyDonHangCF : IEntityTypeConfiguration<QuanLyDonHang>
    {
        public void Configure(EntityTypeBuilder<QuanLyDonHang> builder)
        {
            builder.ToTable("QuanLyDonHang");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.CuaHangId, x.DonHangId });

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.HasOne<CuaHang>(x => x.CuaHang).WithMany(x => x.QuanLyDonHangs)
                .HasForeignKey(x => x.CuaHangId);
            builder.HasOne<DonHang>(x => x.DonHang).WithMany(x => x.QuanLyDonHangs)
                .HasForeignKey(x => x.DonHangId);
            builder.HasOne<NguoiBan>(x => x.NguoiBan).WithMany(x => x.QuanLyDonHangs)
                .HasForeignKey(x => x.NguoiBanId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
