// Copyright 2017 Trekking for Charity
// This file is part of TrekkingForCharity.Api.
// TrekkingForCharity.Api is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// TrekkingForCharity.Api is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
// You should have received a copy of the GNU General Public License along with TrekkingForCharity.Api. If not, see http://www.gnu.org/licenses/.

using System;
using System.IO;
using System.Net.Mime;
using Epoch.net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrekkingForCharity.Api.Client.TestHarness
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            // Application application = new Application(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<Application>();

            
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = GetConfiguration();
            services.AddOptions();
            services.Configure<Settings>(configuration.GetSection("MyOptions"));

            services.AddTransient<Application>();
        }

        

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .Build();
        }
    }
}