// using vigalileo.Data.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;

// namespace marketplace.Data.Configurations
// {
//     public class EntityPermissionConfiguration : IEntityTypeConfiguration<EntityPermission>
//     {
//         public void Configure(EntityTypeBuilder<EntityPermission> builder)
//         {
//             builder.ToTable("EntityPermissions");

//             builder.HasKey(x => x.Id);
//             builder.HasAlternateKey(x => new { x.Action, x.EntityName, x.BitFields });

//             builder.Property(x => x.EntityName).HasColumnType("varchar(256)").IsRequired();
//             builder.Property(x => x.Action).HasColumnType("varchar(16)").IsRequired(true);
//             builder.Property(x => x.BitFields).IsRequired(true).HasDefaultValue(0);
//             builder.Property(x => x.IsUserPermission).HasDefaultValue(false);
//         }
//     }
// }
