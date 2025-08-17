using EventManager.Core.Entities;

namespace EventManager.Application.Models.User.Interfaces;

public interface IUserRepository
{
    Task<Core.Entities.User> Get(string id,bool isReadonly=false);
    Task<IEnumerable<Core.Entities.User>> GetAll(bool isReadonly=false);
    Task<Core.Entities.User> Create(Core.Entities.User user);
    Task<Core.Entities.User> Update(Core.Entities.User user);
    Task Delete(string id);
}