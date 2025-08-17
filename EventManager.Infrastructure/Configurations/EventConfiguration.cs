using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Infrastructure.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events", t =>
        {
            t.HasCheckConstraint("CK_Event_Title", "length(Title) >= 5");
            t.HasCheckConstraint("CK_Event_Location", "length(Location) >= 5");
            t.HasCheckConstraint("CK_Event_Description", "length(Description) >= 20");
            t.HasCheckConstraint("CK_Event_Date", "Date >= current_date");
        });
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e=>e.Title).HasMaxLength(50).IsRequired();
        builder.Property(e=>e.Location).HasMaxLength(50).IsRequired();
        builder.Property(e=>e.Description).HasMaxLength(150).IsRequired();
        builder.Property(e=>e.Date).IsRequired();
        
        builder.HasIndex(e => e.Title).IsUnique();
        builder.HasOne(e => e.Speaker).WithMany(s => s.Events);
    }
}