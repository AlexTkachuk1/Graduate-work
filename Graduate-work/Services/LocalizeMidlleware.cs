using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace Graduate_work.Services
{
    public class LocalizeMidlleware
    {
        private readonly RequestDelegate _next;

        public LocalizeMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userService = context
                .RequestServices.GetService(typeof(UserService)) as UserService;

            var user = userService.GetCurrent();

            var cookceLang = context.Request.Cookies.SingleOrDefault(x => x.Key == "lang");
            
            if (!context.Request.Cookies.Any(x => x.Key == "lang"))
            {
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-EN");
            }
            else
            {
                var cultureName = context.Request.Cookies["lang"];
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(cultureName);
            }


            await _next(context);
        }
    }
}
