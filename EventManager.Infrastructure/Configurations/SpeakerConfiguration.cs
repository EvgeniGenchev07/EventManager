using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infrastructure.Configurations;

public class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
{
    public void Configure(EntityTypeBuilder<Speaker> builder)
    {
        builder.ToTable(nameof(Speaker),t=>
        {
            t.HasCheckConstraint("CK_Speaker_Email", "Email LIKE '%@%' AND length(Email) > 10");
            t.HasCheckConstraint("CK_Speaker_Name", "length(Name) >= 5");
            t.HasCheckConstraint("CK_Speaker_Biography", "length(Biography) >= 20");
        });
        
        builder.HasKey(s => s.Id);
        
        builder.Property(s=>s.Id).ValueGeneratedOnAdd();
        builder.Property(u=>u.Email).HasMaxLength(50).IsRequired();
        builder.Property(s=>s.Biography).HasMaxLength(150).IsRequired();
        builder.Property(s=>s.Name).HasMaxLength(50).IsRequired();
    }
}