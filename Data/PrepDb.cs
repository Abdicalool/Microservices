using PlatFormService.Models;

namespace PlatFormService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
         using( var sericeScope = app.ApplicationServices.CreateScope())
         {
            SeedData(sericeScope.ServiceProvider.GetService<AppDbContext>());
         }  
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.platforms.Any()){
              System.Console.WriteLine("Seeding Data");
              context.platforms.AddRange(
                new Platform(){Name="Java", Publicher="Oracle", Cost="$220"},
                new Platform(){Name="C#", Publicher="Ms", Cost="$220"},
                new Platform(){Name="Swift", Publicher="Apple", Cost="$220"},
                new Platform(){Name="Node", Publicher="Javacript", Cost="$220"}
              );
              context.SaveChanges();
            }else{
              System.Console.WriteLine("We have alreidy a data");
            }
        }
    }
}