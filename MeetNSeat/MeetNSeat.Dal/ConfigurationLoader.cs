using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MeetNSeat.Dal
{
    public static class ConfigurationLoader
    {
        private static IConfiguration _currentConfiguration;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="configuration">The configuration file name.</param>
        /// <returns>Returns the <see cref="IConfiguration"/>.</returns>
        public static IConfiguration GetConfiguration(string configuration)
        {
            if (_currentConfiguration != null)
                return _currentConfiguration;
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string basePath = Directory.GetCurrentDirectory();
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"{configuration}​​​​​​​.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"{configuration}​​​​​​​.{env}​​​​​​​.json", optional: true, reloadOnChange: false);
            return _currentConfiguration = builder.Build();
        }
    }
}


