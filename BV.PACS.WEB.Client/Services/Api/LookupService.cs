using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using BV.PACS.WEB.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Services.Api
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
            var url = _urlMapping.LookupUrl<TemplateLookupItem>();
            return await client.PostJsonAsync<TemplateLookupItem[]>(url,
                new TemplateLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
        public async Task<SourceMaterialTypeLookupItem[]> GetSourceTypeLookupItemLookup(HttpClient client, string lookupType)
        {
            var url = _urlMapping.LookupUrl<SourceMaterialTypeLookupItem>();
            return await client.PostJsonAsync<SourceMaterialTypeLookupItem[]>(url,
                new SourceMaterialTypeLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
        public async Task<BaseLookupItem[]> GetLookup(HttpClient client, BaseLookupTables lookupType)
        {
            var url = _urlMapping.LookupUrl<BaseLookupItem>();
            return await client.PostJsonAsync<BaseLookupItem[]>(url,
                new BaseLookupParameter(lookupType, GlobalSettings.CurrentLanguage));
        }
    }
}