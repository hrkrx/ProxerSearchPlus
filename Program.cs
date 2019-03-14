using System;
using System.IO;
using System.Linq;
using ProxerSearchPlus.controller.proxer.v1;

namespace ProxerSearchPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = ApiClient.GetInstance();
            var apiKey = File.ReadAllText("api.key");
            client.ApiKey = apiKey;
            client.ApiUserAgent = "DotNetCoreApiClientLtP";
            var result = client.Search("test", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null).GetAwaiter().GetResult();
            var entries = result.data.OrderByDescending(x => x.rate_sum / (x.rate_count == 0 ? 1 : x.rate_count));
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}