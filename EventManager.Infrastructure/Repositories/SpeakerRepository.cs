using EventManager.Application.Models.Speaker.Interfaces;
using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infrastructure.Repositories;

public class SpeakerRepository : ISpeakerRepository
{
    private readonly EventManagerDbContext _dbContext;

    public SpeakerRepository(EventManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Speaker> Get(int id, bool includeNavigationalProperties = false, bool isReadonly = false)
    {
        IQueryable<Speaker> query = _dbContext.Speakers;
        if (includeNavigationalProperties) query = query.Include(s => s.Events);
        if (isReadonly) query = query.AsNoTrackingWithIdentityResolution();
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Speaker>> GetAll(bool includeNavigationalProperties = false, bool isReadonly = false)
    {
        IQueryable<Speaker> query = _dbContext.Speakers;
        if (includeNavigationalProperties) query = query.Include(s => s.Events);
        if (isReadonly) query = query.AsNoTrackingWithIdentityResolution();
        return await query.ToListAsync();
    }

    public async Task<Speaker> Create(Speaker speaker)
    {
        List<Event> events = new List<Event>();
        foreach (var @event in speaker.Events)
        {
            Event eventFromDb = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == @event.Id);
            if (eventFromDb == null) events.Add(@event);
            else events.Add(eventFromDb);
        }
        speaker.Events = events;
        _dbContext.Speakers.Add(speaker);
        await _dbContext.SaveChangesAsync();
        return speaker;
    }

    public async Task<Speaker> Update(Speaker speaker, bool includeNavigationalProperties = false)
    {
        Speaker speakerFromDb = await Get(speaker.Id, includeNavigationalProperties);
        if (speakerFromDb == null) throw new KeyNotFoundException("Speaker not found");
        _dbContext.Speakers.Entry(speakerFromDb).GetDatabaseValues().SetValues(speaker);
        if (includeNavigationalProperties)
        {
            List<Event> events = new List<Event>();
            foreach (var @event in speaker.Events)
            {
                Event eventFromDb = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == @event.Id);
                if (eventFromDb == null) events.Add(@event);
                else events.Add(eventFromDb);
            }

            speaker.Events = events;
        }

        await _dbContext.SaveChangesAsync();
        return speaker;
    }

    public async Task Delete(int id)
    {
        Speaker speakerFromDb = await Get(id, false, true);
        _dbContext.Speakers.Remove(speakerFromDb);
        await _dbContext.SaveChangesAsync();
    }
}