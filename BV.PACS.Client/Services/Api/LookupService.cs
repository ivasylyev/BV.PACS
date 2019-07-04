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
        private readonly UrlMappingService _urlMapping;

        public LookupService(UrlMappingService urlMapping)
        {
            _urlMapping = urlMapping;
        }


        public async Task<TemplateLookupItem[]> GetTemplatesLookup(HttpClient client, string lookupType)
        {
            var url = _urlMapping.GetLookupUrl<TemplateLookupItem>();
            return await client.PostJsonAsync<TemplateLookupItem[]>(url,
                new TemplateLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }

        public async Task<BaseLookupItem[]> GetLookup(HttpClient client, BaseLookupTables lookupType)
        {
            var url = _urlMapping.GetLookupUrl<BaseLookupItem>();
            return await client.PostJsonAsync<BaseLookupItem[]>(url,
                new BaseLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
    }
}