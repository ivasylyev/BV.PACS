using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BV.PACS.Shared.Models;
using BV.PACS.Shared.Models.Parameters;
using Dapper;

namespace BV.PACS.Server.Services
{
    public class LookupDbService : DbService
    {
        public LookupDbService()
        {
            SqlMapperEx.InitMapper<TemplateLookupItem>();
            SqlMapperEx.InitMapper<BaseLookupItem>();
        }


        public async Task<IEnumerable<TemplateLookupItem>> GetTemplates(TemplateLookupParameter parameter)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryAsync<TemplateLookupItem>("spCustomizableFormTemplatesByFormType_SelectLookup",
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

        public async Task<IEnumerable<BaseLookupItem>> GetLookup(BaseLookupParameter parameter)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var result = await connection.QueryAsync<BaseLookupItem>(
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