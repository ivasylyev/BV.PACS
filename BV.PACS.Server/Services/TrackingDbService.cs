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
        public TrackingDbService()
        {
            SqlMapperEx.InitMapper<SourceTrackingDto>();

            SqlMapperEx.InitMapper<MaterialGridDto>();
        }


        public async Task<SourceTrackingDto> GetSourceTracking(TrackingParameter parameter)
        {
            return await GetTracking<SourceTrackingDto>(parameter, "dbo.spSource_SelectDetail");
        }

        private async Task<T> GetTracking<T>(TrackingParameter parameter, string spName)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryMultipleAsync(spName,
                    new
                    {
                        LanguageID = parameter.Language,
                        idfSource = parameter.Id
                    },
                    commandType: CommandType.StoredProcedure);
                var sourceTracking = result.ReadSingleOrDefault<T>();
                //todo: implement reading of custom fields
                //var customFields = result.Read();
                return sourceTracking;
            }
        }


        public async Task<IEnumerable<MaterialGridDto>> GetSourceMaterials(GridParameter parameter)
        {
            return await GetSourceGridItems<MaterialGridDto>(parameter, "dbo.spSource_Materials");
        }


        private async Task<IEnumerable<T>> GetSourceGridItems<T>(GridParameter parameter, string spName)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryAsync<T>(spName,
                    new
                    {
                        LanguageID = parameter.Language,
                        idfSource = parameter.Id
                    },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}