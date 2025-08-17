using EventManager.Application.Models.Speaker.Dtos;

namespace EventManager.Core.Services;

public interface ISpeakerService
{
    Task<SpeakerGetDto> Get(int id);
    Task<IEnumerable<SpeakerGetDto>> GetAll();
    Task<SpeakerGetDto> Create(SpeakerCreateDto dto);
    Task<SpeakerGetDto> Update(SpeakerUpdateDto dto);
    Task Delete(int id);
}