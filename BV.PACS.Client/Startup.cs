using BV.PACS.Client.Services.Api;
using BV.PACS.Client.Services.Context;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BV.PACS.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ApplicationContextService>();

            services.AddScoped<UrlMappingService>();
            services.AddScoped<LookupService>();
            services.AddScoped<CatalogService>();
            services.AddScoped<TrackingService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}