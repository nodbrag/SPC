using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace SPC.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
           

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseNLog()
                .UseStartup<Startup>().UseKestrel(options =>
                {
                    //所有controller都不限制post的body大小
                    options.Limits.MaxRequestBodySize = int.MaxValue;
                });
    }
}
