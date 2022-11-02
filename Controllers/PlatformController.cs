using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatFormService.Data;
using PlatFormService.Dto;
using PlatFormService.Models;

namespace PlatFormService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepo repository, IMapper mapper)
       {
        _repository = repository;
        _mapper = mapper;
       }
       //Platform read Dto
      [HttpGet] 
      public ActionResult<IEnumerable<PlatformDto>> Getplatform() 
      {
        System.Console.WriteLine("--> Geting platforms....");
        var platformItems = _repository.GetAllPlatforms(); 
        return Ok(_mapper.Map<IEnumerable<PlatformDto>>(platformItems));
      }

      [HttpGet("{id}", Name = "GetPlatformById")] 
       public ActionResult<PlatformDto> GetPlatformById(int id)
       {
        var platformItem = _repository.GetPlatformById(id);
        if(platformItem != null){
          return Ok(_mapper.Map<PlatformDto>(platformItem));
        }
        return NotFound();
       }
       [HttpPost]
       public ActionResult<PlatformDto> CreatePlatform( PlatformCreateDto platformCreateDto)
       {
             var platformModel = _mapper.Map<Platform>(platformCreateDto);
             _repository.CreatePlatForm(platformModel);
             _repository.SaveChanges();
             var platformReadDto = _mapper.Map<PlatformDto>(platformModel);
             return CreatedAtRoute(nameof(GetPlatformById), new {Id = platformReadDto.Id}, platformReadDto);
       }

    }
}