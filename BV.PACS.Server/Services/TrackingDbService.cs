using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Dapper;

namespace BV.PACS.Server.Services
{
    public class TrackingDbService : DbService
    {
        public async Task<SourceTrackingDto> GetSourceTracking(TrackingParameter parameter)
        {
            return await GetTracking<SourceTrackingDto>(parameter);
        }

        public async Task<MaterialTrackingDto> GetMaterialTracking(TrackingParameter parameter)
        {
            return await GetTracking<MaterialTrackingDto>(parameter);
        }

        public async Task<AliquotTrackingDto> GetAliquotTracking(TrackingParameter parameter)
        {
            return await GetTracking<AliquotTrackingDto>(parameter);
        }

        public async Task<TestTrackingDto> GetTestTracking(TrackingParameter parameter)
        {
            return await GetTracking<TestTrackingDto>(parameter);
        }


        private async Task<T> GetTracking<T>(TrackingParameter parameter)
        {
            var procAttr = SqlMapperEx.GetStoredProcedureAttribute<T>();

            var sqlParameters = new DynamicParameters();
            sqlParameters.Add(procAttr.KeyColumnName, parameter.Id);
            sqlParameters.Add("LanguageID", parameter.Language);

            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryMultipleAsync(procAttr.GetProcedureName,
                    sqlParameters,
                    commandType: CommandType.StoredProcedure);
                var tracking = result.ReadSingleOrDefault<T>();
                //todo: implement reading of custom fields
                //var customFields = result.Read();
                return tracking;
            }
        }


        public async Task<IEnumerable<MaterialGridDto>> GetSourceMaterials(GridParameter parameter)
        {
            return await GetGridItems<MaterialGridDto>(parameter);
        }

        public async Task<IEnumerable<SourceDiagnosticsDto>> GetSourceDiagnostics(GridParameter parameter)
        {
            return await GetGridItems<SourceDiagnosticsDto>(parameter);
        }

        public async Task<IEnumerable<SourceTestGridDto>> GetSourceTests(GridParameter parameter)
        {
            return await GetGridItems<SourceTestGridDto>(parameter);
        }

        public async Task<IEnumerable<AliquotTestGridDto>> GetAliquotTests(GridParameter parameter)
        {
            return await GetGridItems<AliquotTestGridDto>(parameter);
        }

        public async Task<IEnumerable<SourceAuditGridDto>> GetSourceAudit(GridParameter parameter)
        {
            return await GetGridItems<SourceAuditGridDto>(parameter, 
                new Dictionary<string, object> {{"strAuditObjectName", "daoSource"}});
        }

        public async Task<IEnumerable<MaterialAuditGridDto>> GetMaterialAudit(GridParameter parameter)
        {
            return await GetGridItems<MaterialAuditGridDto>(parameter,
                new Dictionary<string, object> {{"strAuditObjectName", "daoStrainPassport"}});
        }

        public async Task<IEnumerable<AliquotAuditGridDto>> GetAliquotAudit(GridParameter parameter)
        {
            return await GetGridItems<AliquotAuditGridDto>(parameter,
                new Dictionary<string, object> { { "strAuditObjectName", "daoVialDetail" } });
        }

        public async Task<IEnumerable<TestAuditGridDto>> GetTestAudit(GridParameter parameter)
        {
            return await GetGridItems<TestAuditGridDto>(parameter,
                new Dictionary<string, object> { { "strAuditObjectName", "daoTest" } });
        }

        private async Task<IEnumerable<T>> GetGridItems<T>(GridParameter parameter, Dictionary<string, object> extraParameters = null)
        {
            var procAttr = SqlMapperEx.GetStoredProcedureAttribute<T>();

            var sqlParameters = new DynamicParameters();
            sqlParameters.Add(procAttr.KeyColumnName, parameter.Id);
            sqlParameters.Add("LanguageID", parameter.Language);

            if (extraParameters != null)
            {
                foreach (var pair in extraParameters)
                {
                    sqlParameters.Add(pair.Key, pair.Value);
                }
            }

            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryAsync<T>(procAttr.GetProcedureName,
                    sqlParameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }


        public async Task PostSourceTracking(TrackingPostParameter<SourceTrackingDto> parameter)
        {
            await PostTracking(parameter);
        }

        public async Task PostMaterialTracking(TrackingPostParameter<MaterialTrackingDto> parameter)
        {
            await PostTracking(parameter);
        }

        public async Task PostAliquotTracking(TrackingPostParameter<AliquotTrackingDto> parameter)
        {
            await PostTracking(parameter);
        }

        public async Task PostTestTracking(TrackingPostParameter<TestTrackingDto> parameter)
        {
            await PostTracking(parameter);
        }

        private async Task PostTracking<T>(TrackingPostParameter<T> parameter) where T : new()
        {
            var procAttr = SqlMapperEx.GetStoredProcedureAttribute<T>();
            var mapping = SqlMapperEx.GetMapping<T>();

            var sqlParameters = new DynamicParameters();
            foreach (var pair in mapping)
            {
                var propName = pair.Key;
                var sqlName = pair.Value;

                var value = typeof(T).GetProperty(propName).GetValue(parameter.Data, null);
                // parameters.Add("@newId", DbType.Int32, direction: ParameterDirection.Output);
                if (sqlName == procAttr.KeyColumnName)
                {
                    sqlParameters.Add(sqlName, value, direction: ParameterDirection.InputOutput);
                }
                else
                {
                    sqlParameters.Add(sqlName, value);
                }
            }

            sqlParameters.Add("Action", 16);
            sqlParameters.Add("LanguageID", parameter.Language);

            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                await connection.ExecuteScalarAsync(procAttr.PostProcedureName, sqlParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}