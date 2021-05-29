using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Configurations
{
    public class CuaHangCF : IEntityTypeConfiguration<CuaHang>
    {
        public void Configure(EntityTypeBuilder<CuaHang> builder)
        {
            builder.ToTable("CuaHang");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Ten);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaCH).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.TenDayDu).HasColumnType("ntext");
            builder.Property(x => x.MoTa).HasColumnType("ntext");

            builder.HasOne<LangNghe>(x => x.LangNghe).WithMany(x => x.CuaHangs).HasForeignKey(x => x.LangNgheId);
        }
    }
}
