using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Configurations
{
    public class GiaoDichCF : IEntityTypeConfiguration<GiaoDich>
    {
        public void Configure(EntityTypeBuilder<GiaoDich> builder)
        {
            builder.ToTable("GiaoDich");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaGD).HasColumnType("nvarchar(32)");
            builder.Property(x => x.ThanhTien).HasColumnType("decimal(15,2)").IsRequired();
            builder.Property(x => x.Phi).HasColumnType("decimal(15,2)").IsRequired();
            builder.Property(x => x.LoiNhan).HasColumnType("ntext");
            builder.Property(x => x.NhaCungCap).HasColumnType("nvarchar(1024)");
        }
    }
}
