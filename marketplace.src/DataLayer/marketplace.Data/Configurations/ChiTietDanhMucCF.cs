﻿using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class ChiTietDanhMucCF : IEntityTypeConfiguration<ChiTietDanhMuc>
    {
        public void Configure(EntityTypeBuilder<ChiTietDanhMuc> builder)
        {
            builder.ToTable("ChiTietDanhMuc");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.DanhMucId, x.NgonNguId });

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);
            
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext");
            builder.Property(x => x.NgonNguId).HasColumnType("varchar(256)").IsRequired();

            builder.HasOne<NgonNgu>(x => x.NgonNgu).WithMany(x => x.ChiTietDanhMucs).HasForeignKey(x => x.NgonNguId);
            builder.HasOne<DanhMuc>(x => x.DanhMuc).WithMany(x => x.ChiTietDanhMucs).HasForeignKey(x => x.DanhMucId);
        }
    }
}
