using Bloodpressure_UI.Classes;
using Bloodpressure_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bloodpressure_UI.Factory
{
    public static class APIClientFactory
    {
        public static Uri uri { get; set; }

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>( () => new ApiClient(uri), LazyThreadSafetyMode.ExecutionAndPublication);

        static APIClientFactory()
        {
            uri = new Uri(ApplicationSettings.WebAPIUrl);
        }
        public static ApiClient Instance => restClient.Value;
    }
}
