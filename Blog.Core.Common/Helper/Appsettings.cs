using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Core.Common
{
    public static class Appsettings
    {
        static IConfiguration Configuration { get; set; }

        static Appsettings()
        {
            Configuration = new ConfigurationBuilder().Add(new JsonConfigurationSource() { Path = "appsettings.json", ReloadOnChange = true }).Build();
        }

        public static string app(params string[] sections)
        {
           
            try
            {
                var val = string.Empty;
                for (int i = 0; i < sections.Length; i++)
                {
                    val += sections[i] + ":";
                }
                return app(val.TrimEnd(':'));
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string app(string key)
        {
            return Configuration[key];
        }
        ///// <summary>
        ///// Redis链接字符串
        ///// </summary>
        //public static string RedisConnectionString = app("AppSettings", "RedisConfig", "ConnectionString");
        ///// <summary>
        ///// SqlServer数据库连接字符串
        ///// </summary>
        //public static string SqlServerConnectionString = app("AppSettings", "SqlServer", "ConnectionString");
    }
}
