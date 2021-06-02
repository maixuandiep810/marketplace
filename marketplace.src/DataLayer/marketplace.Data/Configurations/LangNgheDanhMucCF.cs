﻿using marketplace.Data.Entities;
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
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MaSo).HasColumnType("nvarchar(256)");
            builder.Property(x => x.DaXoa).HasDefaultValue(0);
            builder.Property(x => x.TrangThai).HasDefaultValue(TrangThai.KhongHoatDong);
        }
    }
}
