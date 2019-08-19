using System;
using System.Collections.Generic;
using System.Linq;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Utils;
using Dapper;

namespace BV.PACS.WEB.Server.Services
{
    public static class SqlMapperEx
    {
        public static void InitMappers()
        {
            InitMapper<SourceCatalogDto>();
            InitMapper<MaterialCatalogDto>();
            InitMapper<AliquotCatalogDto>();
            InitMapper<TestCatalogDto>();

            InitMapper<SourceTrackingDto>();
            InitMapper<MaterialTrackingDto>();
            InitMapper<AliquotTrackingDto>();
            InitMapper<TestTrackingDto>();

            InitMapper<MaterialGridDto>();
            InitMapper<SourceTestGridDto>();
            InitMapper<AliquotTestGridDto>();
            InitMapper<SourceDiagnosticsDto>();
            InitMapper<MaterialAliquotGridDto>();
            
            InitMapper<SourceAuditGridDto>();
            InitMapper<MaterialAuditGridDto>();
            InitMapper<AliquotAuditGridDto>();
            InitMapper<TestAuditGridDto>();

            InitMapper<TemplateLookupItem>();
            InitMapper<SourceMaterialTypeLookupItem>();
            InitMapper<BaseLookupItem>();
      
        }

        public static void InitMapper<T>()
        {
            SqlMapper.SetTypeMap(
                typeof(T),
                new CustomPropertyTypeMap(
                    typeof(T),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.Name == columnName ||
                            prop.GetCustomAttributes(false)
                                .OfType<GetColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
        }

        public static StoredProceduresAttribute GetStoredProcedureAttribute<T>()
        {
            var attr = typeof(T).GetCustomAttributes(typeof(StoredProceduresAttribute), true).FirstOrDefault() as StoredProceduresAttribute;
            if (attr == null)
            {
                throw new ArgumentException($"Type {typeof(T)} doesn't have an attribute of type {typeof(StoredProceduresAttribute)}");
            }

            return attr;
        }

        public static Dictionary<string, string> GetMapping<T>()
        {
            var mapping = new Dictionary<string, string>();
            foreach (var prop in typeof(T).GetProperties())
            {
                var postAttribute = prop.GetCustomAttributes(false)
                    .OfType<PostColumnAttribute>()
                    .FirstOrDefault();
                if (postAttribute != null && !postAttribute.Name.IsNullOrEmpty())
                {
                    mapping.Add(prop.Name, postAttribute.Name);
                }
            }

            return mapping;
        }
    }
}