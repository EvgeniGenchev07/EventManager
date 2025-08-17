using AutoMapper;
using EventManager.Application.Models.User.Dtos;
using EventManager.Core.Entities;

namespace EventManager.Application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserGetDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();
    }
}