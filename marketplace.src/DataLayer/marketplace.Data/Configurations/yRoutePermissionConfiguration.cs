// using vigalileo.Data.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace marketplace.Data.Configurations
// {
//     public class RoutePermissionConfiguration : IEntityTypeConfiguration<RoutePermission>
//     {
//         public void Configure(EntityTypeBuilder<RoutePermission> builder)
//         {
//             builder.ToTable("RoutePermissions");

//             builder.HasKey(x => x.Id);
//             builder.HasAlternateKey(x => new { x.PathRegex, x.Action });

//             builder.Property(x => x.Action).HasColumnType("varchar(16)").IsRequired();
//             builder.Property(x => x.PathRegex).HasColumnType("varchar(1024)");
//             builder.Property(x => x.IsAuthenticatedRoute).HasDefaultValue(false);
//         }
//     }
// }
