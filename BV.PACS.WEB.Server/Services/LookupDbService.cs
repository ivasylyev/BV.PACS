using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BV.PACS.WEB.Shared.Models;
using BV.PACS.WEB.Shared.Models.Parameters;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BV.PACS.WEB.Server.Services
{
    public class LookupDbService : DbService
    {
        public LookupDbService(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<TemplateLookupItem>> GetTemplates(TemplateLookupParameter parameter)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = await connection.QueryAsync<TemplateLookupItem>("spCustomizableFormTemplatesByFormType_SelectLookup",
                    new
                    {
                        idfsCFormTypeID = parameter.LookupType,
                        LanguageID = parameter.Language
                    },
                    commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<SourceMaterialTypeLookupItem>> GetSourceMaterialTypes(SourceMaterialTypeLookupParameter parameter)
        {
            var spName = GetSpNameForSourceMaterialLookup(parameter);

            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = await connection.QueryAsync<SourceMaterialTypeLookupItem>(spName,
                    new
                    {
                        LanguageID = parameter.Language
                    },
                    commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        private static string GetSpNameForSourceMaterialLookup(SourceMaterialTypeLookupParameter parameter)
        {
            string spName;
            switch (parameter.LookupType)
            {
                case SourceMaterialTypeLookupParameter.Material:
                    spName = "spMaterialTypeTree2";
                    break;
                case SourceMaterialTypeLookupParameter.Source:
                    spName = "spSourceTypeTree2";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameter.LookupType));
            }

            return spName;
        }

        public async Task<IEnumerable<BaseLookupItem>> GetLookup(BaseLookupParameter parameter)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = await connection.QueryAsync<BaseLookupItem>(
                    "Select idfsReference, [Name], strDefault, intOrder from fnReferenceLookup(@LanguageID, @LookupType) Order By IsNull(intOrder, 0), [Name]",
                    new
                    {
                        LookupType = parameter.LookupType.ToString(),
                        LanguageID = parameter.Language
                    },
                    commandType: CommandType.Text);
                return result;
            }
        }
    }
}