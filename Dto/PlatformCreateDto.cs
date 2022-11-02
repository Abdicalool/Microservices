using System.ComponentModel.DataAnnotations;

namespace PlatFormService.Dto
{
    public class PlatformCreateDto
    {
     [Required]
     public string Name { get; set; }
     [Required]
     public string Publicher { get; set; }
     [Required]
     public string Cost { get; set; }
    }
}