using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class CapTinhCF : IEntityTypeConfiguration<CapTinh>
    {
        public void Configure(EntityTypeBuilder<CapTinh> builder)
        {
            builder.ToTable("CapTinh");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);
            
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)");
        }
    }
}
