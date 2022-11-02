using AutoMapper;
using PlatFormService.Dto;
using PlatFormService.Models;

namespace PlatFormService.Profiles
{
    public class PlatformProfile : Profile
    {
      public PlatformProfile()
      {
        //source to target
        CreateMap<Platform, PlatformDto>();
        CreateMap<PlatformCreateDto, Platform>();
      }
    }
}