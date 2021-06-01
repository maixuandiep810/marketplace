using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class QuyenRouteVaiTroCF : IEntityTypeConfiguration<QuyenRouteVaiTro>
    {
        public void Configure(EntityTypeBuilder<QuyenRouteVaiTro> builder)
        {
            builder.ToTable("QuyenRouteVaiTro");

            builder.HasKey(x => x.Id);
            // builder.HasAlternateKey(x => new { x.PermissionId, x.ApplicationRoleId });

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.HasOne<QuyenRoute>(x => x.QuyenRoute).WithMany(x => x.QuyenRouteVaiTros).HasForeignKey(x => x.QuyenRouteId);
            builder.HasOne<VaiTro>(x => x.VaiTro).WithMany(x => x.QuyenRouteVaiTros).HasForeignKey(x => x.VaiTroId);
        }
    }
}
