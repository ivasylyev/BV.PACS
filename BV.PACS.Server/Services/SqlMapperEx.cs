using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BV.PACS.Shared.Models;
using Dapper;

namespace BV.PACS.Server.Services
{
    public static class SqlMapperEx
    {
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
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
        }

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

            InitMapper<TemplateLookupItem>();
            InitMapper<BaseLookupItem>();

        }
    }
}