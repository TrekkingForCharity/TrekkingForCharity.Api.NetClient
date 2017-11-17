// Copyright 2017 Trekking for Charity
// This file is part of TrekkingForCharity.Api.
// TrekkingForCharity.Api is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
// TrekkingForCharity.Api is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
// You should have received a copy of the GNU General Public License along with TrekkingForCharity.Api. If not, see http://www.gnu.org/licenses/.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Epoch.net;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.Extensions.Options;
using TrekkingForCharity.Api.Client.Models;

namespace TrekkingForCharity.Api.Client.TestHarness
{
    public class Application
    {

        private readonly Settings _settings;

        public Application(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        public async Task Run()
        {
            var token = this.GenerateToken(this._settings.UserId);
            Console.Write(token);

            var client = new ApiClient(new ApiConfiguration());
            var result = await client.PostTrek("Some Trek", "Some Description", DateTime.Now.ToEpoch(), string.Empty);
            if (!result.Success)
            {
                return;
            }
            var trek = result.Result as Trek;
            for (var i = 1; i <= 10; i++)
            {
                await client.PostWaypoint(trek.Id, 1d, 1d, 1234);

            }
        }

        

        public string GenerateToken(string userId)
        {
            var payload = new Dictionary<string, object>
            {
                {"sub", userId},
                { "exp", DateTime.UtcNow.AddHours(1).ToEpoch() }
            };
            var secret = this._settings.Cert;

            var algorithm = new HMACSHA256Algorithm();
            var serializer = new JsonNetSerializer();
            var urlEncoder = new JwtBase64UrlEncoder();
            var encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);
            return token;
        }
    }
}