// using vigalileo.Data.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace marketplace.Data.Configurations
// {
//     public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
//     {
//         public void Configure(EntityTypeBuilder<Permission> builder)
//         {
//             builder.ToTable("Permissions");

//             builder.HasKey(x => x.Id);

//             builder.Property(x => x.Name).HasColumnType("varchar(256)").IsRequired();
//             builder.Property(x => x.Description).HasColumnType("varchar(1024)");

//             builder.HasOne<EntityPermission>(x => x.EntityPermission).WithOne(x => x.Permission).HasForeignKey<EntityPermission>(x => x.PermissionId);
//             builder.HasOne<RoutePermission>(x => x.RoutePermission).WithOne(x => x.Permission).HasForeignKey<RoutePermission>(x => x.PermissionId);
//         }
//     }
// }
