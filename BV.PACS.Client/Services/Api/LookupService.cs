using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Services.Api
{
    public class LookupService
    {

        public async Task<TemplateLookupItem[]> GetTemplatesLookup(HttpClient client, string lookupType)
        {
            return await client.PostJsonAsync<TemplateLookupItem[]>("api/Lookup/GetTemplatesLookup",
                new TemplateLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }

        public async Task<BaseLookupItem[]> GetLookup(HttpClient client, BaseLookupTables lookupType)
        {
            return await client.PostJsonAsync<BaseLookupItem[]>("api/Lookup/GetLookup",
                new BaseLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
    }
}