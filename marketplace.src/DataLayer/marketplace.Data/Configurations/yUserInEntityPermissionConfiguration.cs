// using vigalileo.Data.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace marketplace.Data.Configurations
// {
//     public class UserInEntityPermissionConfiguration : IEntityTypeConfiguration<UserInEntityPermission>
//     {
//         public void Configure(EntityTypeBuilder<UserInEntityPermission> builder)
//         {
//             builder.ToTable("UserInEntityPermissions");
            
//             builder.HasKey(x => x.Id);
//             builder.HasAlternateKey(x => new { x.PermissionId, x.ApplicationUserId });

//             builder.Property(x => x.EntityId).HasColumnType("nvarchar(1024)").IsRequired();

//             builder.HasOne<EntityPermission>(x => x.EntityPermission).WithMany(x => x.UserInEntityPermissions).HasForeignKey(x => x.PermissionId);
//             builder.HasOne<ApplicationUser>(x => x.ApplicationUser).WithMany(x => x.UserInEntityPermissions).HasForeignKey(x => x.ApplicationUserId);
//         }
//     }
// }
