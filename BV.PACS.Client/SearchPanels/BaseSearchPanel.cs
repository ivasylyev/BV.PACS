using System;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.SearchPanels
{
    public class BaseSearchPanel : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; }

        [Parameter]
        public Action<AggregatedConditionDto> OnSearch { get; set; }


        protected async Task<TemplateLookupItem[]> GetTemplatesLookup(string lookupType)
        {
            return await Http.PostJsonAsync<TemplateLookupItem[]>("api/Lookup/GetTemplatesLookup",
                new TemplateLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }

        protected async Task<BaseLookupItem[]> GetLookup(BaseLookupTables lookupType)
        {
            return await Http.PostJsonAsync<BaseLookupItem[]>("api/Lookup/GetLookup",
                new BaseLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
    }
}