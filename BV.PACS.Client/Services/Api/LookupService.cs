using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Services.Api
{
    public class LookupService: ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; }

        public async Task<TemplateLookupItem[]> GetTemplatesLookup(string lookupType)
        {
            return await Http.PostJsonAsync<TemplateLookupItem[]>("api/Lookup/GetTemplatesLookup",
                new TemplateLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }

        public async Task<BaseLookupItem[]> GetLookup(BaseLookupTables lookupType)
        {
            return await Http.PostJsonAsync<BaseLookupItem[]>("api/Lookup/GetLookup",
                new BaseLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
    }
}