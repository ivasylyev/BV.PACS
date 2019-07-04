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

        private readonly Dictionary<Type, string> _urlGridMapping = new Dictionary<Type, string>
        {
            {typeof(MaterialGridDto), "api/Grid/GetSourceMaterials"}
        };

        public string GetCatalogCountUrl<T>()
        {
            return GetUrl<T>(_urlCountMapping);
        }

        public string GetCatalogDataUrl<T>()
        {
            return GetUrl<T>(_urlDataMapping);
        }

        public string GetLookupUrl<T>()
        {
            return GetUrl<T>(_urlLookupMapping);
        }

        public string GetGridUrl<T>()
        {
            return GetUrl<T>(_urlGridMapping);
        }

        private static string GetUrl<T>(Dictionary<Type, string> mapping)
        {
            return mapping.TryGetValue(typeof(T), out var url)
                ? url
                : string.Empty;
        }
    }
}