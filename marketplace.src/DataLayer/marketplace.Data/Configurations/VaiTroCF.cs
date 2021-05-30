using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class VaiTroCF : IEntityTypeConfiguration<VaiTro>
    {
        public void Configure(EntityTypeBuilder<VaiTro> builder)
        {
            builder.ToTable("VaiTro");

            builder.Property(x => x.MoTa).HasColumnType("ntext").IsRequired();

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);
        }
    }
}
