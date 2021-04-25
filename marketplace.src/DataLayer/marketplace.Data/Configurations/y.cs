// using marketplace.Data.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using marketplace.Data.Enums;
// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace marketplace.Data.Configurations
// {
//     public class ContactConfiguration : IEntityTypeConfiguration<Lie>
//     {
//         public void Configure(EntityTypeBuilder<Contact> builder)
//         {
//             builder.ToTable("Contacts");

//             builder.HasKey(x => x.Id);

//             builder.Property(x => x.Id).UseIdentityColumn();
//             builder.Property(x => x.Name).HasColumnType("nvarchar(256)").IsRequired();
//             builder.Property(x => x.Email).HasColumnType("nvarchar(256)").IsRequired();
//             builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(256)").IsRequired();
//             builder.Property(x => x.Status).HasDefaultValue(Status.Active);
//         }
//     }
// }
