using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using marketplace.Data.Enums;

namespace marketplace.Data.Configurations
{
    public class LangNgheDanhMucCF : IEntityTypeConfiguration<LangNgheDanhMuc>
    {
        public void Configure(EntityTypeBuilder<LangNgheDanhMuc> builder)
        {
            builder.ToTable("LangNgheDanhMuc");

            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => new { x.LangNgheId, x.DanhMucId });

            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);

            builder.HasOne<LangNghe>(x => x.LangNghe).WithMany(x => x.LangNgheDanhMucs)
                .HasForeignKey(x => x.LangNgheId);
            builder.HasOne<DanhMuc>(x => x.DanhMuc).WithMany(x => x.LangNgheDanhMucs)
                .HasForeignKey(x => x.DanhMucId);
        }
    }
}
