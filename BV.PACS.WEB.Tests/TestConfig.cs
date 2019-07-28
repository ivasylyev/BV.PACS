using System;
using Microsoft.Extensions.Configuration;

namespace BV.PACS.WEB.Tests
{
    public class TestConfig
    {
        public static IConfiguration GetConfig()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }
}