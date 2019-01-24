using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pivotal.Extensions.Configuration.ConfigServer;
using Steeltoe.Extensions.Logging;

namespace HelloWorldDotNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, configBuilder) =>
                {
                    var env = builderContext.HostingEnvironment;
                    configBuilder.SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables()
                        .AddConfigServer(env.EnvironmentName);
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConfiguration(context.Configuration.GetSection("Logging"));
                    builder.AddDynamicConsole();
                })
                .Build();

            host.Run();
        }

    }
}
