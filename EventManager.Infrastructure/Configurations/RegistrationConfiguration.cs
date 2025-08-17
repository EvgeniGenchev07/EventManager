using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infrastructure.Configurations;

public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
{
    public void Configure(EntityTypeBuilder<Registration> builder)
    {
        builder.ToTable(nameof(Registration));
        
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Property(r=>r.RegistrationDate).IsRequired();

        builder.HasOne(r => r.Event).WithMany().IsRequired();
        builder.HasOne(r => r.User).WithMany().IsRequired();
    }
}