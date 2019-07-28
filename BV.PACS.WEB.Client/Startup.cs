using System.Threading.Tasks;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Client.Services.Context;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using Toolbelt.Blazor.I18nText;

namespace BV.PACS.WEB.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddI18nText<Startup>(GetConfigure);

            services.AddScoped<ApplicationContextService>();

            services.AddScoped<UrlMappingService>();
            services.AddScoped<LookupService>();
            services.AddScoped<CatalogService>();
            services.AddScoped<TrackingService>();
        }

        private void GetConfigure(I18nTextOptions options)
        {
            options.GetInitialLanguageAsync = async (provider, textOptions) => await Task.Run(() => "en-US");
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}