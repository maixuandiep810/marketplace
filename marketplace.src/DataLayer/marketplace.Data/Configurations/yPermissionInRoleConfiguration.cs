// using vigalileo.Data.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace marketplace.Data.Configurations
// {
//     public class PermissionInRoleConfiguration : IEntityTypeConfiguration<PermissionInRole>
//     {
//         public void Configure(EntityTypeBuilder<PermissionInRole> builder)
//         {
//             builder.ToTable("PermissionInRoles");
            
//             builder.HasKey(x => x.Id);
//             builder.HasAlternateKey(x => new { x.PermissionId, x.ApplicationRoleId });

//             builder.HasOne<Permission>(x => x.Permission).WithMany(x => x.PermissionInRoles).HasForeignKey(x => x.PermissionId);
//             builder.HasOne<ApplicationRole>(x => x.ApplicationRole).WithMany(x => x.PermissionInRoles).HasForeignKey(x => x.ApplicationRoleId);
//         }
//     }
// }
