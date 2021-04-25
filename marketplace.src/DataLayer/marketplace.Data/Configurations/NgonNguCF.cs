using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace marketplace.Data.Configurations
{
    public class NgonNguCF : IEntityTypeConfiguration<NgonNgu>
    {
        public void Configure(EntityTypeBuilder<NgonNgu> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnType("varchar(16)").IsRequired();
            builder.Property(x => x.MaNN).HasColumnType("varchar(32)").IsRequired();
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
        }
    }
}
