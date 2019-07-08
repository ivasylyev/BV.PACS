using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Client.Services.Api;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared.Base
{
    public class GridPanel<TModel> : ComponentBase where TModel : new()
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private UrlMappingService MappingService { get; set; }

        [Inject]
        private HttpClient Http { get; set; }

        protected TModel[] DataSource { get; set; }

        protected override async Task OnInitAsync()
        {
            var url = MappingService.GridUrl<TModel>();
            DataSource = await Http.PostJsonAsync<TModel[]>(url, new GridParameter(Id, GlobalSettings.CurrentLanguage));
        }
    }
}