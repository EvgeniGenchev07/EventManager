using AutoMapper;
using EventManager.Application.Models.Registration.Dtos;
using EventManager.Core.Entities;

namespace EventManager.Application.Profiles;

public class RegistrationProfile : Profile
{
    public RegistrationProfile()
    {
        CreateMap<Registration, RegistrationGetDto>();
        CreateMap<RegistrationCreateDto, Registration>()
            .ForMember(r=>r.RegistrationDate,
                opt=>opt.MapFrom(src=>DateTime.Now));
    }
}