using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class NguoiBanCF : IEntityTypeConfiguration<NguoiBan>
    {
        public void Configure(EntityTypeBuilder<NguoiBan> builder)
        {
            builder.ToTable("NguoiBan");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.TaiKhoanId);

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.MaNB).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext").IsRequired();

            builder.HasOne<CuaHang>(x => x.CuaHang).WithMany(x => x.NguoiBans).HasForeignKey(x => x.CuaHangId);
        }
    }
}
