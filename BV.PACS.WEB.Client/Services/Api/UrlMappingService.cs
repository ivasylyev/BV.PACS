using System;
using System.Collections.Generic;
using BV.PACS.WEB.Shared.Models;

namespace BV.PACS.WEB.Client.Services.Api
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

        private readonly Dictionary<Type, string> _urlGetTrackingMapping = new Dictionary<Type, string>
        {
            {typeof(AliquotTrackingDto), "api/Tracking/GetAliquot"},
            {typeof(MaterialTrackingDto), "api/Tracking/GetMaterial"},
            {typeof(SourceTrackingDto), "api/Tracking/GetSource"},
            {typeof(TestTrackingDto), "api/Tracking/GetTest"}
        };
        private readonly Dictionary<Type, string> _urlPostTrackingMapping = new Dictionary<Type, string>
        {
            {typeof(AliquotTrackingDto), "api/Tracking/PostAliquot"},
            {typeof(MaterialTrackingDto), "api/Tracking/PostMaterial"},
            {typeof(SourceTrackingDto), "api/Tracking/PostSource"},
            {typeof(TestTrackingDto), "api/Tracking/PostTest"}
        };

        private readonly Dictionary<Type, string> _urlLookupMapping = new Dictionary<Type, string>
        {
            {typeof(TemplateLookupItem), "api/Lookup/GetTemplatesLookup"},
            {typeof(SourceMaterialTypeLookupItem), "api/Lookup/GetSourceMaterialTypeLookup"},
            {typeof(BaseLookupItem), "api/Lookup/GetLookup"}
        };

        private readonly Dictionary<Type, string> _urlGridMapping = new Dictionary<Type, string>
        {
            {typeof(MaterialGridDto), "api/Grid/GetSourceMaterials"},
            {typeof(SourceTestGridDto), "api/Grid/GetSourceTests"},
            {typeof(AliquotTestGridDto), "api/Grid/GetAliquotTests"},
            {typeof(SourceDiagnosticsDto), "api/Grid/GetSourceDiagnostics"},
            {typeof(MaterialAliquotGridDto), "api/Grid/GetMaterialAliquots"},

            {typeof(SourceAuditGridDto), "api/Grid/GetSourceAudit"},
            {typeof(MaterialAuditGridDto), "api/Grid/GetMaterialAudit"},
            {typeof(AliquotAuditGridDto), "api/Grid/GetAliquotAudit"},
            {typeof(TestAuditGridDto), "api/Grid/GetTestAudit"},
        };

       

        public string CatalogCountUrl<T>()
        {
            return GetUrl<T>(_urlCountMapping);
        }

        public string CatalogDataUrl<T>()
        {
            return GetUrl<T>(_urlDataMapping);
        }

        public string GetTrackingUrl<T>()
        {
            return GetUrl<T>(_urlGetTrackingMapping);
        }

        public string PostTrackingUrl<T>()
        {
            return GetUrl<T>(_urlPostTrackingMapping);
        }

        public string LookupUrl<T>()
        {
            return GetUrl<T>(_urlLookupMapping);
        }

        public string GridUrl<T>()
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