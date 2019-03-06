using System;
using System.IO;
using ProxerSearchPlus.controller.v1;

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
            var result = client.Search("test", null, null, null, null, null, null, null, null, null, null, null, null, null).GetAwaiter().GetResult();
            
            Console.WriteLine(result);
        }
    }
}
