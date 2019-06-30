using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Client.Services.Api;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Shared.Base
{
    public class TrackingPanel<T> : ComponentBase where T : new()
    {
        [Parameter]
        protected int Id { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected LookupService ApiLookupService { get; set; }

        protected T TrackingObject { get; set; }
        protected TemplateLookupItem[] Templates { get; set; }


        protected override async Task OnInitAsync()
        {
            await GetLookups();
            await GetData();
        }

        protected virtual async Task GetLookups()
        {
            Templates = await ApiLookupService.GetTemplatesLookup(Http, FormTypes.Source);
        }

        private async Task GetData()
        {
            TrackingObject = await GetData(new TrackingParameter(Id, BaseSettings.Language));
        }

        private async Task<T> GetData(TrackingParameter parameter)
        {
            var attr = typeof(T).GetCustomAttributes(typeof(DataUrlAttribute), false).FirstOrDefault();
            if (attr is DataUrlAttribute urlAttribute)
            {
                return await Http.PostJsonAsync<T>(urlAttribute.Url, parameter);
            }

            return default;
        }
    }
}