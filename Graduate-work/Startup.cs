using AutoMapper;
using Graduate_work.EfStuff;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper.Configuration;
using System.Reflection;
using Graduate_work.EfStuff.Repositories;
using System.Linq;
using Graduate_work.Services;
using Graduate_work.Model;
using Graduate_work.Models;

namespace Graduate_work
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Project;Integrated Security=True;";
            services.AddDbContext<ProjectDbContext>(x => x.UseSqlServer(connectString));

            repositoriesRegistration(services);

            registerMapper(services);

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();
        }
        private void repositoriesRegistration(IServiceCollection service)
        {
            var assembly = Assembly.GetAssembly(typeof(BaseRepository<>));

            var repositories = assembly.GetTypes()
                .Where(x => x.IsClass
                && x.BaseType.IsGenericType
                && x.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>));

            foreach (var repositoiryType in repositories)
            {
                service.ServiceHelper(repositoiryType);
            }
        }
        private void registerMapper(IServiceCollection services)
        {
            var provider = new MapperConfigurationExpression();

            provider.CreateMap<User, RegistrationViewModel>();

            provider.CreateMap<RegistrationViewModel, User>();

            var mapperConfiguration = new MapperConfiguration(provider);
            var mapper = new Mapper(mapperConfiguration);

            services.AddScoped<IMapper>(x => mapper);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
