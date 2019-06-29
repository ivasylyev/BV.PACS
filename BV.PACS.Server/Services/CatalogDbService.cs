using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using Dapper;

namespace BV.PACS.Server.Services
{
    public class CatalogDbService : DbService
    {
        public CatalogDbService()
        {
            SqlMapperEx.InitMapper<SourceCatalogDto>();
            SqlMapperEx.InitMapper<MaterialCatalogDto>();
            SqlMapperEx.InitMapper<AliquotCatalogDto>();
            SqlMapperEx.InitMapper<TestCatalogDto>();
        }


        public async Task<IEnumerable<SourceCatalogDto>> GetSources(AggregatedConditionDto condition)
        {
            return await GetCatalogItems<SourceCatalogDto>(condition, "dbo.spSource_QS");
        }

        public async Task<IEnumerable<MaterialCatalogDto>> GetMaterials(AggregatedConditionDto condition)
        {
            return await GetCatalogItems<MaterialCatalogDto>(condition, "dbo.spStrain_QS");
        }

        public async Task<IEnumerable<AliquotCatalogDto>> GetAliquots(AggregatedConditionDto condition)
        {
            return await GetCatalogItems<AliquotCatalogDto>(condition, "dbo.spVial_QS");
        }

        public async Task<IEnumerable<TestCatalogDto>> GetTests(AggregatedConditionDto condition)
        {
            return await GetCatalogItems<TestCatalogDto>(condition, "dbo.spTest_QS");
        }

        private async Task<IEnumerable<T>> GetCatalogItems<T>(AggregatedConditionDto condition, string spName)
        {
            var xml = condition.Serialize();

            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryAsync<T>(spName,
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
    }
}