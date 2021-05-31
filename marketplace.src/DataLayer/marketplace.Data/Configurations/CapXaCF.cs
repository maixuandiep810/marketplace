using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class CapXaCF : IEntityTypeConfiguration<CapXa>
    {
        public void Configure(EntityTypeBuilder<CapXa> builder)
        {
            builder.ToTable("CapXa");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Ten);

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.MaXa).HasColumnType("nvarchar(256)");
            
            builder.HasOne<CapHuyen>(x => x.CapHuyen).WithMany(x => x.CapXas).HasForeignKey(x => x.CapHuyenId);
        }
    }
}
