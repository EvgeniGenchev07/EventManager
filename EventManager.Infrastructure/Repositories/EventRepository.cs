using EventManager.Application.Models.Event.Interfaces;
using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EventManager.Infrastructure.Repositories;

public class EventRepository : IEventRepository
{
    private readonly EventManagerDbContext _dbContext;
    public EventRepository(EventManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Event> Get(int id, bool includeNavigationalProperties = false, bool isReadonly = false)
    {
        IQueryable<Event> query = _dbContext.Events;
        if (includeNavigationalProperties) query = query.Include(e => e.Speaker);
        if (isReadonly) query = query.AsNoTrackingWithIdentityResolution();
        return await query.FirstOrDefaultAsync(e => e.Id == id);

    }

    public async Task<IEnumerable<Event>> GetAll(bool includeNavigationalProperties = false, bool isReadonly = false)
    {
        IQueryable<Event> query = _dbContext.Events;
        if(includeNavigationalProperties) query = query.Include(e => e.Speaker);
        if (isReadonly) query = query.AsNoTrackingWithIdentityResolution();
        return await query.ToListAsync();
    }

    public async Task<Event> Create(Event @event)
    {
        if (@event.Speaker is not null)
        {
            Speaker speakerFromDb = await _dbContext.Speakers.FirstOrDefaultAsync(s => s.Id == @event.Speaker.Id);
            if (speakerFromDb is not null) @event.Speaker = speakerFromDb;
        }
        await _dbContext.Events.AddAsync(@event);
        await _dbContext.SaveChangesAsync();
        return @event;
    }

    public async Task<Event> Update(Event @event, bool includeNavigationalProperties = false)
    {
        Event eventFromDb = await Get(@event.Id, includeNavigationalProperties);
        if (eventFromDb == null) throw new KeyNotFoundException("Event not found");
        _dbContext.Entry(eventFromDb).GetDatabaseValues().SetValues(@event);
        if (includeNavigationalProperties)
        {
            Speaker speakerFromDb = await _dbContext.Speakers.FirstOrDefaultAsync(s => s.Id == @event.Speaker.Id);
            if(speakerFromDb == null) eventFromDb.Speaker = @event.Speaker;
            else  eventFromDb.Speaker = speakerFromDb;
        }
        await _dbContext.SaveChangesAsync();
        return @event;
    }

    public async Task Delete(int id)
    {
        Event eventFromDb = await Get(id, false,true);
        if (eventFromDb == null) throw new KeyNotFoundException("Event not found");
        _dbContext.Events.Remove(eventFromDb);
        await _dbContext.SaveChangesAsync();
    }
}