using System;
using ProxerSearchPlus.controller.v1;

namespace ProxerSearchPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = ApiClient.GetInstance();
            var result = client.Search("test", null, null, null, null, null, null, null, null, null, null, null, null, null).GetAwaiter().GetResult();
            Console.WriteLine("Hello World!");
        }
    }
}
