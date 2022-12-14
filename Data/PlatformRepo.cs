using PlatFormService.Models;

namespace PlatFormService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatForm(Platform plat)
        {
            if(plat ==null){
               throw new ArgumentNullException(nameof(plat));
            }
            _context.platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
           return _context.platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }
    }
}