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
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.MoTa).HasColumnType("ntext");

            builder.HasOne(a => a.CuaHang).WithOne(a => a.NguoiBan).HasForeignKey<CuaHang>(c => c.NguoiBanId);
        }
    }
}
