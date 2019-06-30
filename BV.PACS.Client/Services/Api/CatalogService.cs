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
            var attr = typeof(T).GetCustomAttributes(typeof(CountUrlAttribute), false).FirstOrDefault();
            if (attr is CountUrlAttribute urlAttribute)
            {
                return await client.PostJsonAsync<int>(urlAttribute.Url, cond) / cond.PageSize;
            }

            return 0;
        }

        public async Task<T[]> GetData<T>(HttpClient client, AggregatedConditionDto cond)
        {
            var attr = typeof(T).GetCustomAttributes(typeof(DataUrlAttribute), false).FirstOrDefault();
            if (attr is DataUrlAttribute urlAttribute)
            {
                return await client.PostJsonAsync<T[]>(urlAttribute.Url, cond);
            }

            return new T[0];
        }
    }
}