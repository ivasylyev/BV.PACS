using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.WEB.Client.Services.Api
{
    public class NumberingService
    {
        private readonly UrlMappingService _urlMapping;

        public NumberingService(UrlMappingService urlMapping)
        {
            _urlMapping = urlMapping;
        }

        public async Task<string[]> GetSourceNextNumbers(HttpClient client, int numberCount)
        {
            return await GetNextNumbers(client, NumberingObject.SourceBarcode, numberCount);
        }

        public async Task<string[]> GetMaterialNextNumbers(HttpClient client, int numberCount)
        {
            return await GetNextNumbers(client, NumberingObject.MaterialNumber, numberCount);
        }

        public async Task<string[]> GetAliquotNextNumbers(HttpClient client, int numberCount)
        {
            return await GetNextNumbers(client, NumberingObject.VialBarcode, numberCount);
        }

        public async Task<string[]> GetTestNextNumbers(HttpClient client, int numberCount)
        {
            return await GetNextNumbers(client, NumberingObject.TestBarcode, numberCount);
        }

        private async Task<string[]> GetNextNumbers(HttpClient client, string numberName, int numberCount)
        {
            var url = _urlMapping.NumberingUrl<string>();
            return await client.PostJsonAsync<string[]>(url, new NumberingParameter(numberName, numberCount));
        }
    }
}