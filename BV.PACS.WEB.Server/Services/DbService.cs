﻿using Microsoft.Extensions.Configuration;

namespace BV.PACS.WEB.Server.Services
{
    public class DbService
    {
        protected string ConnectionString { get; private set; }

        public DbService(IConfiguration config)
        {
            
            ConnectionString = config.GetConnectionString(System.Environment.MachineName);
            if (string.IsNullOrEmpty(ConnectionString))
            {
                ConnectionString = config.GetConnectionString("DefaultConnection");
            }
        }
    }
}