using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProxerSearchPlus.model.v1;

namespace ProxerSearchPlus.controller.v1
{
    public class ApiClient
    {
        private static ApiClient instance; 
        private HttpClient client { get; set; }

        public string ApiKey { get; set; }

        private ApiClient()
        {
            client = new HttpClient();
        }

        public static ApiClient GetInstance()
        {
            if (instance == null)
            {
                instance = new ApiClient();
            }
            return instance;
        }

        public async Task<EntrySearch> Search(string name, string language, string type, string genre, string nogenre, 
                                                string taggenre, string notaggenre, string fsk, string sort, string length, 
                                                string lengthlimit, string tags, string tagratefilter, string limit)
        {
            var endPoint = "https://proxer.me/api/v1/list/entrysearch";
            EntrySearch result;
            
            var request = CreatMessage(endPoint);

            if (!string.IsNullOrWhiteSpace(name))
                request.Properties.Add("name", name);
            if (!string.IsNullOrWhiteSpace(language))
                request.Properties.Add("language", language);
            if (!string.IsNullOrWhiteSpace(type))
                request.Properties.Add("type", type);
            if (!string.IsNullOrWhiteSpace(genre))
                request.Properties.Add("genre", genre);
            if (!string.IsNullOrWhiteSpace(nogenre))
                request.Properties.Add("nogenre", nogenre);
            if (!string.IsNullOrWhiteSpace(taggenre))
                request.Properties.Add("taggenre", taggenre);
            if (!string.IsNullOrWhiteSpace(notaggenre))
                request.Properties.Add("notaggenre", notaggenre);
            if (!string.IsNullOrWhiteSpace(fsk))
                request.Properties.Add("fsk", fsk);
            if (!string.IsNullOrWhiteSpace(sort))
                request.Properties.Add("sort", sort);
            if (!string.IsNullOrWhiteSpace(length))
                request.Properties.Add("length", length);
            if (!string.IsNullOrWhiteSpace(lengthlimit))
                request.Properties.Add("length-limit", lengthlimit);
            if (!string.IsNullOrWhiteSpace(tags))
                request.Properties.Add("tags", tags);
            if (!string.IsNullOrWhiteSpace(tagratefilter))
                request.Properties.Add("tagratefilter", tagratefilter);
            if (!string.IsNullOrWhiteSpace(limit))
                request.Properties.Add("limit", limit);

            var response = await client.SendAsync(request);

            result = JsonConvert.DeserializeObject<EntrySearch>(await response.Content.ReadAsStringAsync());

            return result;
        }

        private HttpRequestMessage CreatMessage(string endPoint, bool testMode = false)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endPoint);
            
            if (string.IsNullOrWhiteSpace(ApiKey))
                testMode = true;
            else
                request.Headers.Add("proxer-api-key", ApiKey);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "DotNetCoreApiClientLtP");

            if (testMode)
                request.Properties.Add("api_testmode", 1);

            return request;
        }
    }
}