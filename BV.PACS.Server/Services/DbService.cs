using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Dapper;

namespace BV.PACS.Server.Services
{
    public class DbService
    {
        protected readonly SqlConnectionStringBuilder _builder;

        public DbService()
        {
            _builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-A0AN5I9\\PACS",
                UserID = "sa",
                Password = "btrp!2010",
                InitialCatalog = "PACS_PrachiBMORU_200K"
            };

            SqlMapperEx.InitMapper<MaterialGridDto>();


            SqlMapperEx.InitMapper<SourceTrackingDto>();

            SqlMapperEx.InitMapper<TemplateLookupItem>();
            SqlMapperEx.InitMapper<BaseLookupItem>();
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