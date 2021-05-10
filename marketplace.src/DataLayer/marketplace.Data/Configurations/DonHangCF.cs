using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class DonHangCF : IEntityTypeConfiguration<DonHang>
    {
        public void Configure(EntityTypeBuilder<DonHang> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaDH).HasColumnType("varchar(32)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.ThanhTien).HasColumnType("decimal(15,2)");
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThaiDonHang.DangXuLy);


            builder.HasOne<KhachHang>(x => x.KhachHang).WithMany(x => x.DonHangs).HasForeignKey(x => x.KhachHangId);
            builder.HasOne<GiaoDich>(x => x.GiaoDich).WithOne(x => x.DonHang).HasForeignKey<GiaoDich>(x => x.DonHangId);
        }
    }
}
