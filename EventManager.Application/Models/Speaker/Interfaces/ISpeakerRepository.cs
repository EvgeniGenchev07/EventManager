using EventManager.Core.Entities;

namespace EventManager.Application.Models.Speaker.Interfaces;

public interface ISpeakerRepository
{
    Task<Core.Entities.Speaker> Get(int id,bool includeNavigationalProperties=false,bool isReadonly=false);
    Task<IEnumerable<Core.Entities.Speaker>> GetAll(bool includeNavigationalProperties=false,bool isReadonly=false);
    Task<Core.Entities.Speaker> Create(Core.Entities.Speaker speaker);
    Task<Core.Entities.Speaker> Update(Core.Entities.Speaker speaker,bool includeNavigationalProperties=false);
    Task Delete(int id);
}