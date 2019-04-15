using System;
using System.IO;
using System.Linq;
using ProxerSearchPlus.Caching;
using ProxerSearchPlus.Controller.Proxer.v1;
using ProxerSearchPlus.Model.Proxer.v1;

namespace ProxerSearchPlus
{
    // this class is for testing purposes so that a browser is not needed for simple experimentation
    class Program
    {
        static void Main(string[] args)
        {
            var client = ApiClient.GetInstance();
            var apiKey = File.ReadAllText("api.key");
            client.ApiKey = apiKey;
            client.ApiUserAgent = "DotNetCoreApiClientLtP";
            var result = client.Search("Gacha").GetAwaiter().GetResult();
            var entries = result.data.OrderByDescending(x => x.rate_sum / (x.rate_count == 0 ? 1 : x.rate_count));
            
            var fullEntry = client.GetFullEntry(entries.First().id, true).GetAwaiter().GetResult();

            Console.WriteLine(fullEntry);
            
            CachingController.CacheAllCacheableProperties(fullEntry.data, fullEntry.data.id);

            var data = client.GetFullEntry(entries.First().id).GetAwaiter().GetResult().data;

            CachingController.PopulateEntryFromCache(data, data.id);

            Console.WriteLine(data);

        }
    }
}