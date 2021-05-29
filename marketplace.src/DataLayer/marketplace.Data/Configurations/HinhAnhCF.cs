using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Configurations
{
    public class HinhAnhCF : IEntityTypeConfiguration<HinhAnh>
    {
        public void Configure(EntityTypeBuilder<HinhAnh> builder)
        {
            builder.ToTable("HinhAnh");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaHA).HasColumnType("nvarchar(256)");
            builder.Property(x => x.MoTa).HasColumnType("ntext");
            builder.Property(x => x.Url).HasColumnType("ntext");
            builder.Property(x => x.TieuDe).HasColumnType("nvarchar(256)");
            builder.Property(x => x.DoiTuongId).HasColumnType("nvarchar(256)");
            builder.Property(x => x.Loai).HasColumnType("ntext");

        }
    }
}
