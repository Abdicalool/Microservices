using PlatFormService.Models;

namespace PlatFormService.Data
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();

        Platform GetPlatformById(int id);

        void CreatePlatForm(Platform plat);

    }
}