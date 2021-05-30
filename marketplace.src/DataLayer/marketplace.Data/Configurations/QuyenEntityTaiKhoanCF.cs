using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class QuyenEntityTaiKhoanCF : IEntityTypeConfiguration<QuyenEntityTaiKhoan>
    {
        public void Configure(EntityTypeBuilder<QuyenEntityTaiKhoan> builder)
        {
            builder.ToTable("QuyenEntityTaiKhoan");

            builder.HasKey(x => x.Id);
            // builder.HasAlternateKey(x => new { x.PermissionId, x.ApplicationRoleId });

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.HasOne<QuyenEntity>(x => x.QuyenEntity).WithMany(x => x.QuyenEntityTaiKhoans).HasForeignKey(x => x.QuyenEntityId);
            builder.HasOne<TaiKhoan>(x => x.TaiKhoan).WithMany(x => x.QuyenEntityTaiKhoans).HasForeignKey(x => x.TaiKhoanId);
        }
    }
}
