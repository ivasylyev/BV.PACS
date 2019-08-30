using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BV.PACS.WEB.Shared.Models.Parameters;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BV.PACS.WEB.Server.Services
{
    public class NumberingDbService : DbService
    {
        public NumberingDbService(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<string>> GetNextNumbers(NumberingParameter parameter)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var result = await connection.QueryAsync<string>("spGetNextNumberRange",
                    new
                    {
                        NextNumberName = parameter.Name, parameter.Count
                    },
                    commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}