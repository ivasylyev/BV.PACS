using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BV.PACS.Client.Services.Api
{
    public class CatalogService
    {
        private readonly Dictionary<Type, string> _urlDataMapping = new Dictionary<Type, string>
        {
            {typeof(AliquotCatalogDto), "api/Catalog/GetAliquots"},
            {typeof(MaterialCatalogDto), "api/Catalog/GetMaterials"},
            {typeof(SourceCatalogDto), "api/Catalog/GetSources"},
            {typeof(TestCatalogDto), "api/Catalog/GetTests"}
        };

        private readonly Dictionary<Type, string> _urlCountMapping = new Dictionary<Type, string>
        {
            {typeof(AliquotCatalogDto), "api/Catalog/GetAliquotsRecordCount"},
            {typeof(MaterialCatalogDto), "api/Catalog/GetMaterialsRecordCount"},
            {typeof(SourceCatalogDto), "api/Catalog/GetSourcesRecordCount"},
            {typeof(TestCatalogDto), "api/Catalog/GetTestsRecordCount"}
        };

        public async Task<int> GetPageCount<T>(HttpClient client, AggregatedConditionDto cond)
        {
            if (_urlCountMapping.ContainsKey(typeof(T)))
            {
                var url = _urlCountMapping[typeof(T)];
                return await client.PostJsonAsync<int>(url, cond) / cond.PageSize;
            }

            return 0;
        }

        public async Task<T[]> GetData<T>(HttpClient client, AggregatedConditionDto cond)
        {
            if (_urlDataMapping.ContainsKey(typeof(T)))
            {
                var url = _urlDataMapping[typeof(T)];
                return await client.PostJsonAsync<T[]>(url, cond);
            }

            return new T[0];
        }
    }
}