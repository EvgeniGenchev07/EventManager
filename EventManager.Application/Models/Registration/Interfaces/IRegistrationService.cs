using EventManager.Application.Models.Registration.Dtos;

namespace EventManager.Core.Services;

public interface IRegistrationService
{
    Task<RegistrationGetDto> Get(int id);
    Task<IEnumerable<RegistrationGetDto>> GetAll();
    Task<RegistrationGetDto> Create(RegistrationCreateDto dto);
    Task Delete(int id);
}