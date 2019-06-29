using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
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

            InitMapper<MaterialGridDto>();

            InitMapper<SourceCatalogDto>();
            InitMapper<MaterialCatalogDto>();
            InitMapper<AliquotCatalogDto>();
            InitMapper<TestCatalogDto>();

            InitMapper<SourceTrackingDto>();

            InitMapper<TemplateLookupItem>();
            InitMapper<BaseLookupItem>();
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


        public IEnumerable<SourceCatalogDto> GetSources(AggregatedConditionDto condition)
        {
            return GetCatalogItems<SourceCatalogDto>(condition, "dbo.spSource_QS");
        }

        public IEnumerable<MaterialCatalogDto> GetMaterials(AggregatedConditionDto condition)
        {
            return GetCatalogItems<MaterialCatalogDto>(condition, "dbo.spStrain_QS");
        }

        public IEnumerable<AliquotCatalogDto> GetAliquots(AggregatedConditionDto condition)
        {
            return GetCatalogItems<AliquotCatalogDto>(condition, "dbo.spVial_QS");
        }

        public IEnumerable<TestCatalogDto> GetTests(AggregatedConditionDto condition)
        {
            return GetCatalogItems<TestCatalogDto>(condition, "dbo.spTest_QS");
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

        public int GetAliquotsRecordCount(AggregatedConditionDto condition)
        {
            return GetCatalogRecordCount(condition, "dbo.spVial_QS_RecordsCount");
        }

        public int GetTestsRecordCount(AggregatedConditionDto condition)
        {
            return GetCatalogRecordCount(condition, "dbo.spTest_QS_RecordsCount");
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


        public SourceTrackingDto GetSourceTracking(TrackingParameter parameter)
        {
            return GetTracking<SourceTrackingDto>(parameter, "dbo.spSource_SelectDetail");
        }

        private T GetTracking<T>(TrackingParameter parameter, string spName)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = connection.QueryMultiple(spName,
                    new
                    {
                        LanguageID = parameter.Language,
                        idfSource = parameter.Id
                    },
                    commandType: CommandType.StoredProcedure);
                var sourceTracking = result.ReadSingleOrDefault<T>();
                //todo: implement reading of custom fields
                var customFields = result.Read();
                return sourceTracking;
            }
        }


        public IEnumerable<MaterialGridDto> GetSourceMaterials(GridParameter parameter)
        {
            return GetSourceGridItems<MaterialGridDto>(parameter, "dbo.spSource_Materials");
        }
       

        private IEnumerable<T> GetSourceGridItems<T>(GridParameter parameter, string spName)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = connection.Query<T>(spName,
                    new
                    {
                        LanguageID = parameter.Language,
                        idfSource = parameter.Id
                    },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public IEnumerable<TemplateLookupItem> GetTemplates(TemplateLookupParameter parameter)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = connection.Query<TemplateLookupItem>("spCustomizableFormTemplatesByFormType_SelectLookup",
                    new
                    {
                        idfsCFormTypeID = parameter.LookupType,
                        LanguageID = parameter.Language
                    },
                    commandType: CommandType.StoredProcedure);
                //return null;
                return result;
            }
        }

        public IEnumerable<BaseLookupItem> GetLookup(BaseLookupParameter parameter)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = connection.Query<BaseLookupItem>(
                    "Select idfsReference, [Name], strDefault, intOrder from fnReferenceLookup(@LanguageID, @LookupType) Order By IsNull(intOrder, 0), [Name]",
                    new
                    {
                        LookupType = parameter.LookupType.ToString(),
                        LanguageID = parameter.Language
                    },
                    commandType: CommandType.Text);
                //return null;
                return result;
            }
        }
    }
}