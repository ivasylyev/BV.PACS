using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Client.Services.Api;
using BV.PACS.WEB.Shared.Models.Parameters;
using BV.PACS.WEB.Shared.Utils;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor.I18nText.Interfaces;

namespace BV.PACS.WEB.Client.Shared.Base
{
    public class GridPanel<TModel, TTranslation> : TranslatablePanel<TTranslation>
        where TModel : new() where TTranslation : class, I18nTextFallbackLanguage, new()
    {
        [Inject]
        private UrlMappingService MappingService { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected TModel[] DataSource { get; set; }

        protected override async Task OnInitAsync()
        {
            await base.OnInitAsync();
            var url = MappingService.GridUrl<TModel>();
            DataSource = await Http.PostJsonAsync<TModel[]>(url, new GridParameter(Id, GlobalSettings.CurrentLanguage));
        }
    }
}