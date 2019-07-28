using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BV.PACS.WEB.Shared.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BV.PACS.WEB.Server.Services
{
    public class CatalogDbService : DbService
    {
        public CatalogDbService(IConfiguration config) : base(config)
        {
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

            using (var connection = new SqlConnection(ConnectionString))
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

        public async Task<int> GetSourcesRecordCount(AggregatedConditionDto condition)
        {
            return await GetCatalogRecordCount(condition, "dbo.spSource_QS_RecordCount");
        }

        public async Task<int> GetMaterialsRecordCount(AggregatedConditionDto condition)
        {
            return await GetCatalogRecordCount(condition, "dbo.spStrain_QS_RecordCount");
        }

        public async Task<int> GetAliquotsRecordCount(AggregatedConditionDto condition)
        {
            return await GetCatalogRecordCount(condition, "dbo.spVial_QS_RecordsCount");
        }

        public async Task<int> GetTestsRecordCount(AggregatedConditionDto condition)
        {
            return await GetCatalogRecordCount(condition, "dbo.spTest_QS_RecordsCount");
        }

        private async Task<int> GetCatalogRecordCount(AggregatedConditionDto condition, string spName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var xml = condition.Serialize();

                var result = await connection.ExecuteScalarAsync<int>(spName,
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