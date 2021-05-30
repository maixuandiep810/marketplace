using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class TaiKhoanCF : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.ToTable("TaiKhoan");

            builder.Property(x => x.HoTen).HasColumnType("nvarchar(256)").IsRequired();

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.HasOne<KhachHang>(x => x.KhachHang).WithOne(x => x.TaiKhoan).HasForeignKey<KhachHang>(x => x.TaiKhoanId);
            builder.HasOne<NguoiBan>(x => x.NguoiBan).WithOne(x => x.TaiKhoan).HasForeignKey<NguoiBan>(x => x.TaiKhoanId);

            // builder.Ignore(u => u.Claims);
            // builder.Ignore(u => u.Logins);
        }
    }
}
