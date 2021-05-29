using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace marketplace.Data.Configurations
{
    public class QuyenRouteCF : IEntityTypeConfiguration<QuyenRoute>
    {
        public void Configure(EntityTypeBuilder<QuyenRoute> builder)
        {
            builder.ToTable("QuyenRoute");

            builder.HasKey(x => x.Id);
            // builder.HasAlternateKey(x => new { x.HanhDong, x.Ten });

            builder.Property(x => x.Ten).HasColumnType("varchar(256)").IsRequired();
            builder.Property(x => x.MoTa).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.HanhDong).HasColumnType("varchar(256)").IsRequired(true);
            builder.Property(x => x.PathRegex).HasColumnType("ntext").IsRequired(true);
        }
    }
}
