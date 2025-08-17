using EventManager.Core.Entities;

namespace EventManager.Application.Models.Registration.Interfaces;

public interface IRegistrationRepository
{
    Task<Core.Entities.Registration> Get(int id, bool isReadonly=false);
    Task<IEnumerable<Core.Entities.Registration>> GetAll(bool isReadonly=false);
    Task<Core.Entities.Registration> Create(Core.Entities.Registration registration);
    Task Delete(int id);
}