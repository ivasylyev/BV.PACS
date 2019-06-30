using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    }
}