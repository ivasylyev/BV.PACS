using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using BV.PACS.Shared.Utils;
using Dapper;

namespace BV.PACS.Server.Services
{
    public class TrackingDbService : DbService
    {
        public async Task<SourceTrackingDto> GetSourceTracking(TrackingParameter parameter)
        {
            var sqlParameter = new
            {
                LanguageID = parameter.Language,
                idfSource = parameter.Id
            };
            return await GetTracking<SourceTrackingDto>(sqlParameter, "dbo.spSource_SelectDetail");
        }

        public async Task<MaterialTrackingDto> GetMaterialTracking(TrackingParameter parameter)
        {
            var sqlParameter = new
            {
                LanguageID = parameter.Language,
                idfMaterial = parameter.Id
            };
            return await GetTracking<MaterialTrackingDto>(sqlParameter, "dbo.spStrainPassport_SelectDetail");
        }

        public async Task<AliquotTrackingDto> GetAliquotTracking(TrackingParameter parameter)
        {
            var sqlParameter = new
            {
                LanguageID = parameter.Language,
                idfContainer = parameter.Id
            };
            return await GetTracking<AliquotTrackingDto>(sqlParameter, "dbo.spVial_SelectDetail");
        }

        public async Task<TestTrackingDto> GetTestTracking(TrackingParameter parameter)
        {
            var sqlParameter = new
            {
                LanguageID = parameter.Language,
                idfTest = parameter.Id
            };
            return await GetTracking<TestTrackingDto>(sqlParameter, "dbo.spTest_SelectDetail");
        }

        private async Task<T> GetTracking<T>(object sqlParameter, string spName)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryMultipleAsync(spName,
                    sqlParameter,
                    commandType: CommandType.StoredProcedure);
                var tracking = result.ReadSingleOrDefault<T>();
                //todo: implement reading of custom fields
                //var customFields = result.Read();
                return tracking;
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


        public async Task PostSourceTracking(TrackingPostParameter<SourceTrackingDto> parameter)
        {
            await PostTracking<SourceTrackingDto>(parameter, "dbo.spSource_Post");
//            //todo: implement
//            var data = parameter.Data;
//            var sqlParameter = new
//            {
//                LanguageID = parameter.Language,
//                Action = 16,
//                idfSource = data.SourceId,
//                strBarcode = data.SourceBarcode,
//                datRegistration_Date = data.SourceRegistrationDate,
//                idfsCFormTemplateID = data.SourceTemplateId,
//                strNote = data.SourceNote,
//                idfsSourceType = data.SourceTypeId,
//                idfsGeoLocation = data.GeoLocationId,
//                idfOwner = data.OwnerId,
//                Source_idfGeoLocation = data.AddressGeoLocationId,
//                strLocationDesription = data.GeoLocationDescription
//            };
//            using (var connection = new SqlConnection(_builder.ConnectionString))
//            {
//                var result = connection.ExecuteScalar("spSource_Post", sqlParameter, commandType: CommandType.StoredProcedure);
//            }
        }

        private async Task PostTracking<T>(TrackingPostParameter<SourceTrackingDto> parameter, string spName)
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

            var sqlParameters = new DynamicParameters();
            sqlParameters.Add("Action", 16);
            sqlParameters.Add("LanguageID", parameter.Language);
            foreach (var pair in mapping)
            {
                var propName = pair.Key;
                var sqlName = pair.Value;

                var value = typeof(T).GetProperty(propName).GetValue(parameter.Data, null);
                // parameters.Add("@newId", DbType.Int32, direction: ParameterDirection.Output);
                sqlParameters.Add(sqlName, value);
            }

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