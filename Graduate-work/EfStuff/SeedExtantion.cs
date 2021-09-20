using Graduate_work.EfStuff.Repositories;
using Graduate_work.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Graduate_work.EfStuff
{
    public static class SeedExtantion
    {
        public static IHost Seed(this IHost host)
        {
            using (var service = host.Services.CreateScope())
            {
                InitUsers(service.ServiceProvider);
            }

            return host;
        }

        private static void InitUsers(IServiceProvider service)
        {
            var userRepository = service.GetService<UserRepository>();
            if (!userRepository.Exist(Role.Admin))
            {
                var admin = new User()
                {
                    Login = "Admin",
                    Password = "rgjinlk", 
                    Role = Role.Admin
                };

                userRepository.Save(admin);
            }
        }
    }
}
