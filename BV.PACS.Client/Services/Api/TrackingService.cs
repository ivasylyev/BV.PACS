using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Services.Api
{
    public class TrackingService
    {
        private readonly UrlMappingService _urlMapping;

        public TrackingService(UrlMappingService urlMapping)
        {
            _urlMapping = urlMapping;
        }

        public async Task<T> GetData<T>(HttpClient client, TrackingParameter parameter) where T : new()
        {
            var url = _urlMapping.GetTrackingUrl<T>();
            return url.IsNullOrEmpty()
                ? default
                : await client.PostJsonAsync<T>(url, parameter);
        }

        public async Task PostData<T>(HttpClient client, TrackingPostParameter<T> parameter) where T : new()
        {
            var url = _urlMapping.PostTrackingUrl<T>();
            if (!url.IsNullOrEmpty())
            {
                await client.PostJsonAsync<T>(url, parameter);
            }
        }
    }
}