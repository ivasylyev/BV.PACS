using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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