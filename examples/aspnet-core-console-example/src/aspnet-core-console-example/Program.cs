using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using NLog.Extensions.Logging;

namespace aspnet_core_console_example
{
    public class Program
    {
        public Program(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
        }

        public static void Main(string[] args)
        {
            //DI won't work outside ASP.NET Core since RC2.

            var services = new ServiceCollection();
            var container = services.BuildServiceProvider();
            var LoggerFactory = container.GetService<LoggerFactory>();

            // PlatformServices.Default.Runtime.

            Console.WriteLine("TEST");
            Console.WriteLine("press any key to Exit");
            Console.ReadLine();
        }
    }


}
