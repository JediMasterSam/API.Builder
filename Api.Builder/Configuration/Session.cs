using System;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using static System.IO.Path;
using static System.Uri;
using static Microsoft.Extensions.Hosting.Host;

namespace Api.Builder
{
    public static class Session
    {
        public static void Run<TStartup>(this Assembly assembly, string[] args) where TStartup : Startup
        {
            Assembly = assembly;
            Path = GetDirectoryName(UnescapeDataString(new UriBuilder(assembly.CodeBase).Path));

            CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<TStartup>(); }).Build().Run();
        }

        internal static Assembly Assembly { get; private set; }

        internal static string Path { get; private set; }
    }
}