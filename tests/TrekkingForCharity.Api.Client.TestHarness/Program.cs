// Copyright 2017 Trekking for Charity
// This file is part of TrekkingForCharity.Api.
// TrekkingForCharity.Api is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// TrekkingForCharity.Api is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
// You should have received a copy of the GNU General Public License along with TrekkingForCharity.Api. If not, see http://www.gnu.org/licenses/.

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Epoch.net;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
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

            var token = GenerateToken("abc");
            Console.Write(token);
            while (true)
            {
                
            }
            var client = new ApiClient(new ApiConfiguration());
            var result = client.PostTrek("Some Trek", "Some Description", DateTime.Now.ToEpoch(), string.Empty);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            
        }

        public static string GenerateToken(string userId)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();

            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);
            var payload = new Dictionary<string, object>
            {
                {"claim1", 0},
                {"claim2", "claim2-value"},
                { "exp", secondsSinceEpoch }
            };
            var secret =
                "";

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            
            var token = encoder.Encode(payload, secret);
            return token;
        }
    }

    public class Application
    {
        ILogger _logger;

        public Application(IOptions<MyOptions> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task Run()
        {
            try
            {
                _logger.LogInformation($"This is a console application for {_settings.Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}