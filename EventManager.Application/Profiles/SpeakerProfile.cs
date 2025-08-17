using AutoMapper;
using EventManager.Application.Models.Speaker.Dtos;
using EventManager.Core.Entities;

namespace EventManager.Application.Profiles;

public class SpeakerProfile : Profile
{
    public SpeakerProfile()
    {
        CreateMap<Speaker, SpeakerGetDto>();
        CreateMap<SpeakerCreateDto, Speaker>();
        CreateMap<SpeakerUpdateDto, Speaker>();
    }
}