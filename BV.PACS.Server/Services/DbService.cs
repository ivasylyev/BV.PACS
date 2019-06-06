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

        public IEnumerable<SourceListItem> GetSources()
        {
            using (var connection = new SqlConnection(_builder.ConnectionString))
            {
                var sourceSql = @"<?xml version=""1.0""?>
                    <ConditionRoot>
                        <ConditionList />
                        <SortList />
                    </ConditionRoot>";

                var result = connection.Query<SourceListItem>("dbo.spSource_QS",
                    new {SearchConditionXml = sourceSql, LanguageID = "en", intStart = 0, intCount = 50},
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}