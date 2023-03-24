using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model.SeedData;
using StudentManagingSystem.Model;

namespace StudentManagingSystem.Configurations
{
    public static class DatabaseStartUp
    {
        public static IApplicationBuilder UseApplicationDatabase<T>(this IApplicationBuilder app,
            IServiceProvider serviceProvider)
        {

            using (var scope = serviceProvider.CreateScope())
            {
                //var services = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<SmsDbContext>();
                context.Database.Migrate();
                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                IdentitySeedData.Seed(context, userMgr, roleMgr).Wait();
            }

            return app;
        }
    }
}
