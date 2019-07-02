using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Services.Api
{
    public class CatalogService
    {
        public async Task<int> GetPageCount<T>(HttpClient client, AggregatedConditionDto cond)
        {
            var attr = typeof(T).GetCustomAttributes(typeof(GetCountUrlAttribute), false).FirstOrDefault();
            if (attr is GetCountUrlAttribute urlAttribute)
            {
                return await client.PostJsonAsync<int>(urlAttribute.Url, cond) / cond.PageSize;
            }

            return 0;
        }

        public async Task<T[]> GetData<T>(HttpClient client, AggregatedConditionDto cond)
        {
            var attr = typeof(T).GetCustomAttributes(typeof(GetDataUrlAttribute), false).FirstOrDefault();
            if (attr is GetDataUrlAttribute urlAttribute)
            {
                return await client.PostJsonAsync<T[]>(urlAttribute.Url, cond);
            }

            return new T[0];
        }
    }
}