using EventManager.Application.Models.Registration.Interfaces;
using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infrastructure.Repositories;

public class RegistrationRepository : IRegistrationRepository
{
    private readonly EventManagerDbContext _dbContext;

    public RegistrationRepository(EventManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Registration> Get(int id, bool isReadonly = false)
    {
        IQueryable<Registration> query = _dbContext.Registrations;
        if (isReadonly) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Registration>> GetAll(bool isReadonly = false)
    {
        IQueryable<Registration> query = _dbContext.Registrations;
        if (isReadonly) query = query.AsNoTracking();
        return await query.ToListAsync();
    }

    public async Task<Registration> Create(Registration registration)
    {
        Event eventFromDb = await _dbContext.Events.FirstOrDefaultAsync(e => e.Id == registration.Event.Id);
        if (eventFromDb == null) throw new KeyNotFoundException("Event not found");
        registration.Event = eventFromDb;
        User user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == registration.User.Id);
        if (user == null) throw new KeyNotFoundException("User not found");
        registration.User = user;
        _dbContext.Registrations.Add(registration);
        await _dbContext.SaveChangesAsync();
        return registration;
    }

    public async Task Delete(int id)
    {
        Registration registrationFromDb = await Get(id,true);
        if (registrationFromDb == null) throw new KeyNotFoundException("Registration not found");
        _dbContext.Registrations.Remove(registrationFromDb);
        await _dbContext.SaveChangesAsync();
    }
}