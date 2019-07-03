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
            return await GetSourceGridItems<MaterialGridDto>(parameter);
        }


        private async Task<IEnumerable<T>> GetSourceGridItems<T>(GridParameter parameter)
        {
            var procAttr = SqlMapperEx.GetStoredProcedureAttribute<T>();

            var sqlParameters = new DynamicParameters();
            sqlParameters.Add(procAttr.KeyColumnName, parameter.Id);
            sqlParameters.Add("LanguageID", parameter.Language);

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
            await PostTracking<SourceTrackingDto>(parameter, "dbo.spSource_Post");
        }

        private async Task PostTracking<T>(TrackingPostParameter<SourceTrackingDto> parameter, string spName)
        {
            var mapping = SqlMapperEx.GetMapping<T>();

            var sqlParameters = new DynamicParameters();


            foreach (var pair in mapping)
            {
                var propName = pair.Key;
                var sqlName = pair.Value;

                var value = typeof(T).GetProperty(propName).GetValue(parameter.Data, null);
                // parameters.Add("@newId", DbType.Int32, direction: ParameterDirection.Output);
                sqlParameters.Add(sqlName, value);
            }

            sqlParameters.Add("Action", 16);
            sqlParameters.Add("LanguageID", parameter.Language);

            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                await connection.ExecuteScalarAsync(spName, sqlParameters, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task PostMaterialTracking(TrackingPostParameter<MaterialTrackingDto> parameter)
        {
            //todo: implement
        }

        public async Task PostAliquotTracking(TrackingPostParameter<AliquotTrackingDto> parameter)
        {
            //todo: implement
        }

        public async Task PostTestTracking(TrackingPostParameter<TestTrackingDto> parameter)
        {
            //todo: implement
        }
    }
}