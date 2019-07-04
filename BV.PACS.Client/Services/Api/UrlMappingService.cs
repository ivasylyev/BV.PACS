using System;
using System.Collections.Generic;
using BV.PACS.Shared.Models;

namespace BV.PACS.Client.Services.Api
{
    public class UrlMappingService
    {
        // todo: move to config
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

        private readonly Dictionary<Type, string> _urlLookupMapping = new Dictionary<Type, string>
        {
            {typeof(TemplateLookupItem), "api/Lookup/GetTemplatesLookup"},
            {typeof(BaseLookupItem), "api/Lookup/GetLookup"}
        };
        public string GetCatalogCountUrl<T>()
        {
            return _urlCountMapping.TryGetValue(typeof(T), out string url) 
                ? url 
                : string.Empty;
        }
        public string GetCatalogDataUrl<T>()
        {
            return _urlDataMapping.TryGetValue(typeof(T), out string url)
                ? url
                : string.Empty;
        }

        public string GetLookupUrl<T>()
        {
            return _urlLookupMapping.TryGetValue(typeof(T), out string url)
                ? url
                : string.Empty;
        }
    }
}