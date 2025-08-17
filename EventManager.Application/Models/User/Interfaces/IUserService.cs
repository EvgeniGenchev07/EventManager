using EventManager.Application.Models.User.Dtos;

namespace EventManager.Core.Services;

public interface IUserService
{
    Task<UserGetDto> Get(string id);
    Task<IEnumerable<UserGetDto>> GetAll();
    Task<UserGetDto> Create(UserCreateDto dto);
    Task<UserGetDto> Update(UserUpdateDto dto);
    Task Delete(string id);
}