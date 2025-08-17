using System.ComponentModel.DataAnnotations;
using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), t =>
        {
            t.HasCheckConstraint("CK_User_Email", "Email LIKE '%@%' AND length(Email) > 10");
            t.HasCheckConstraint("CK_User_First_Name", "length(FirstName) >= 3");
            t.HasCheckConstraint("CK_User_Last_Name", "length(LastName) >= 3");
            t.HasCheckConstraint("CK_User_Role", "Role between 0 and 2");
        });
        
        builder.HasKey(x => x.Id);

        builder.Property(u => u.Id).HasMaxLength(50).ValueGeneratedOnAdd();
        builder.Property(u=>u.Email).HasMaxLength(50).IsRequired();
        builder.Property(u=>u.Password).HasMaxLength(100).IsRequired();
        builder.Property(u=>u.FirstName).HasMaxLength(20).IsRequired();
        builder.Property(u=>u.LastName).HasMaxLength(20).IsRequired();
        builder.Property(u=>u.Role).IsRequired();
        
        builder.HasIndex(u=>u.Email).IsUnique();
    }
}