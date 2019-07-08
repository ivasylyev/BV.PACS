using BV.PACS.Client.Services.Api;
using BV.PACS.Client.Services.Context;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BV.PACS.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddI18nText<Startup>();

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