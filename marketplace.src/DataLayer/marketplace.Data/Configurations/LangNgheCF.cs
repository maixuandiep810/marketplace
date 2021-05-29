﻿using marketplace.Data.Entities;
using marketplace.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace.Data.Configurations
{
    public class LangNgheCF : IEntityTypeConfiguration<LangNghe>
    {
        public void Configure(EntityTypeBuilder<LangNghe> builder)
        {
            builder.ToTable("LangNghe");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Ten);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MaLN).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.Ten).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(x => x.TenDayDu).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext").IsRequired();
        }
    }
}
