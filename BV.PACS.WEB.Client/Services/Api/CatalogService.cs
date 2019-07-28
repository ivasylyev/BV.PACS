using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Services.Api
{
    public class CatalogService
    {
        private readonly UrlMappingService _urlMapping;

        public CatalogService(UrlMappingService urlMapping)
        {
            _urlMapping = urlMapping;
        }

        public async Task<int> GetPageCount<T>(HttpClient client, AggregatedConditionDto cond)
        {
            var url = _urlMapping.CatalogCountUrl<T>();
            return url.IsNullOrEmpty()
                ? 0
                : await client.PostJsonAsync<int>(url, cond) / cond.PageSize;
        }

        public async Task<T[]> GetData<T>(HttpClient client, AggregatedConditionDto cond)
        {
            var url = _urlMapping.CatalogDataUrl<T>();
            return url.IsNullOrEmpty()
                ? new T[0]
                : await client.PostJsonAsync<T[]>(url, cond);
        }
    }
}