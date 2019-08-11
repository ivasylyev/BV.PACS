using System;
using Microsoft.Extensions.Configuration;

namespace BV.PACS.WEB.Server.Services
{
    public class DbService
    {
        protected string ConnectionString { get; }

        public DbService(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString(Environment.MachineName);
            if (string.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = config.GetConnectionString("DefaultConnection");
            }
        }
    }
}