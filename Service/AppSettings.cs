using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.MongoConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class AppSettings
    {
        public static MongoSetting MongoSettings { get; set; }
        public static IConfiguration Keys { get; set; }
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            MongoSettings = configuration.GetSection("MongoSettings").Get<MongoSetting>();
            Keys = configuration.GetSection("AppSettings");
        }
    }
}
