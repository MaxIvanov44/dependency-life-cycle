using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace dependency_life_cycle
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<Icounter, RandomCounter>();
            //services.AddScoped<Icounter, RandomCounter>();
            services.AddTransient<RandomCounter>();
            services.AddTransient<Icounter>(provider => {
                var counter = provider.GetService<RandomCounter>();
                return counter;
            });
            services.AddTransient<CounterService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CounterMiddleware>();
        }
    }
}

