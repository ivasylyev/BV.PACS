using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BV.PACS.Shared.Models;
using Dapper;

namespace BV.PACS.Server.Services
{
    public class DbService
    {
        private readonly SqlConnectionStringBuilder _builder;

        public DbService()
        {
            _builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-A0AN5I9\\PACS",
                UserID = "sa",
                Password = "btrp!2010",
                InitialCatalog = "PACS_PrachiBMORU_200K"
            };


            InitMapper<SourceListItem>();
            InitMapper<MaterialListItem>();
            InitMapper<TemplateListItem>();
        }

        private static void InitMapper<T>()
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


        public IEnumerable<SourceListItem> GetSources(AggregatedConditionDto condition)
        {
            return GetCatalogItems<SourceListItem>(condition, "dbo.spSource_QS");
        }

        public IEnumerable<MaterialListItem> GetMaterials(AggregatedConditionDto condition)
        {
            return GetCatalogItems<MaterialListItem>(condition, "dbo.spStrain_QS");
        }

        private IEnumerable<T> GetCatalogItems<T>(AggregatedConditionDto condition, string spName)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var xml = condition.Serialize();
                var result = connection.Query<T>(spName,
                    new
                    {
                        SearchConditionXml = xml,
                        LanguageID = condition.Language,
                        intStart = condition.PageNumber * condition.PageSize,
                        intCount = condition.PageSize
                    },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public int GetSourcesRecordCount(AggregatedConditionDto condition)
        {
            return GetCatalogRecordCount(condition, "dbo.spSource_QS_RecordCount");
        }

        public int GetMaterialsRecordCount(AggregatedConditionDto condition)
        {
            return GetCatalogRecordCount(condition, "dbo.spStrain_QS_RecordCount");
        }


        private int GetCatalogRecordCount(AggregatedConditionDto condition, string spName)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var xml = condition.Serialize();

                var result = connection.ExecuteScalar<int>(spName,
                    new
                    {
                        SearchConditionXml = xml,
                        LanguageID = condition.Language
                    },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<TemplateListItem> GetTemplates(string formType, string language)
        {
          
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
              
                var result = connection.Query<TemplateListItem>("spCustomizableFormTemplatesByFormType_SelectLookup",
                    new
                    {
                        idfsCFormTypeID = formType,
                        LanguageID = language
                       
                    },
                    commandType: CommandType.StoredProcedure);
                //return null;
                return result;
            }
        }
    }
}