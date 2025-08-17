using EventManager.Application.Models.User.Interfaces;
using EventManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EventManagerDbContext _dbContext;

    public UserRepository(EventManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Get(string id, bool isReadonly = false)
    {
        IQueryable<User> query = _dbContext.Users;
        if (isReadonly) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<User>> GetAll(bool isReadonly = false)
    {
        IQueryable<User> query = _dbContext.Users;
        if (isReadonly) query = query.AsNoTracking();
        return await query.ToListAsync();
    }

    public async Task<User> Create(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(User user)
    {
        User userFromDb = await Get(user.Id);
        if (userFromDb == null) throw new KeyNotFoundException("User not found");
        _dbContext.Users.Entry(userFromDb).GetDatabaseValues().SetValues(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task Delete(string id)
    {
        User userFromDb = await Get(id, true);
        if (userFromDb == null) throw new KeyNotFoundException("User not found");
        _dbContext.Users.Remove(userFromDb);
        await _dbContext.SaveChangesAsync();
    }
}