using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
namespace Graduate_work.Services
{
    public static class RegisterHelper
    {
        public static void ServiceHelper<T>(this IServiceCollection services)
        {
            var type = typeof(T);
            ServiceHelper(services, type);
        }
        public static void ServiceHelper(this IServiceCollection services , Type type)
        {
            services.AddScoped(type, serviceProvider =>
            {
                var constructor = type.GetConstructors()
                 .OrderByDescending(x => x.GetParameters())
                 .First();

                var parametersInfo = constructor.GetParameters();
                var parameterType = parametersInfo
                .Select(x => serviceProvider.GetService(x.ParameterType))
                .ToArray();

                return constructor.Invoke(parameterType);
            });
        }
    }
}


