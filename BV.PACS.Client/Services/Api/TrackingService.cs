using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Services.Api
{
    public class TrackingService
    {
        public async Task<T> GetData<T>(HttpClient client, TrackingParameter parameter) where T : new()
        {
            var attr = typeof(T).GetCustomAttributes(typeof(GetDataUrlAttribute), false).FirstOrDefault();
            if (attr is GetDataUrlAttribute urlAttribute)
            {
                return await client.PostJsonAsync<T>(urlAttribute.Url, parameter);
            }

            return default;
        }

        public async Task PostData<T>(HttpClient client, TrackingPostParameter<T> parameter) where T : new()
        {
            var attr = typeof(T).GetCustomAttributes(typeof(PostDataUrlAttribute), false).FirstOrDefault();
            if (attr is PostDataUrlAttribute urlAttribute)
            {
                 await client.PostJsonAsync<T>(urlAttribute.Url, parameter);
            }
        }
    }
}