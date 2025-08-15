using Microsoft.EntityFrameworkCore;

namespace EventManager.Core.Model;

public class EventManagerDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public EventManagerDbContext():base(){}
    public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options):  base(options){}

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source=EventManager.db3");
        base.OnConfiguring(optionsBuilder);
    }
}