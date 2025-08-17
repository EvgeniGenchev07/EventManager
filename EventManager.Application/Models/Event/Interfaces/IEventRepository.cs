using  EventManager.Application.Models.Event.Dtos;
using EventManager.Core.Entities;

namespace EventManager.Application.Models.Event.Interfaces;

public interface IEventRepository
{
    Task<Core.Entities.Event> Get(int id,bool includeNavigationalProperties=false,bool isReadonly=false);
    Task<IEnumerable<Core.Entities.Event>> GetAll(bool includeNavigationalProperties=false,bool isReadonly=false);
    Task<Core.Entities.Event> Create(Core.Entities.Event @event);
    Task<Core.Entities.Event> Update(Core.Entities.Event @event,bool includeNavigationalProperties=false);
    Task Delete(int id);
}