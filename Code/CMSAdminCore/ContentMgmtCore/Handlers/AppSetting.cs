using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContentMgmtCore.Handlers
{
    static class ConfigurationHelper
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationHelper()
        {
            AppSetting = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        }
    }

    public class Config
    {
        public Jwt jwt { get; set; }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ClaimName { get; set; }
        public int ExpireSeconds { get; set; }
    }
}