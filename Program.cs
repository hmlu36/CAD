
using Dotnet.Utils.Logger;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace CAD {
    public class Program {

        public static void Main(string[] args) {

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostContext, logging) => {
                    var env = hostContext.HostingEnvironment;
                    logging.AddProvider(new Log4netProvider(Path.Combine(env.ContentRootPath, "Properties/log4net.config")));
                })
                .ConfigureAppConfiguration((hostContext, configurationBinder) => { // 讀取連線設定
                    var env = hostContext.HostingEnvironment;
                    configurationBinder.AddJsonFile(Path.Combine(env.ContentRootPath, "Properties/settings.json"), optional: true, reloadOnChange: true);
                });
    }
}


