using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class JwtTokenCF : IEntityTypeConfiguration<JwtToken>
    {
        public void Configure(EntityTypeBuilder<JwtToken> builder)
        {
            builder.ToTable("JwtToken");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.Id).UseIdentityColumn();
            
            builder.HasOne<TaiKhoan>(x => x.TaiKhoan).WithMany(x => x.JwtTokens).HasForeignKey(x => x.TaiKhoanId);
        }
    }
}
