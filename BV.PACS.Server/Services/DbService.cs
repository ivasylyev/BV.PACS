using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BV.PACS.Shared.Models;
using Dapper;

namespace BV.PACS.Server.Services
{
    public class DbService
    {
        private readonly SqlConnectionStringBuilder _builder;

        public DbService()
        {
            _builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-A0AN5I9\\PACS",
                UserID = "sa",
                Password = "btrp!2010",
                InitialCatalog = "PACS_PrachiBMORU_200K"
            };

            SqlMapper.SetTypeMap(
                typeof(SourceListItem),
                new CustomPropertyTypeMap(
                    typeof(SourceListItem),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.Name == columnName ||
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
        }


        public IEnumerable<SourceListItem> GetSources(AggregatedConditionDto condition)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var xml = condition.Serialize();
                var result = connection.Query<SourceListItem>("dbo.spSource_QS",
                    new
                    {
                        SearchConditionXml = xml, LanguageID = "en", intStart = condition.PageNumber * condition.PageSize,
                        intCount = condition.PageSize
                    },
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public int GetSourcesRecordCount(AggregatedConditionDto condition)
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var xml = condition.Serialize();

                var result = connection.ExecuteScalar<int>("dbo.spSource_QS_RecordCount",
                    new {SearchConditionXml = xml, LanguageID = "en"},
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}