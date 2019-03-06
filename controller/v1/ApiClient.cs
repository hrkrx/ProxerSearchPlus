using System.Collections.Generic;
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

        public string ApiUserAgent { get; set; }

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
                                                string lengthlimit, string tags, string tagratefilter, string limit,
                                                string page, string tagspoilerfilter)
        {
            var endPoint = "https://proxer.me/api/v1/list/entrysearch";
            EntrySearch result;
            
            
            var postParameters = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(name))
                postParameters.Add("name", name);
            if (!string.IsNullOrWhiteSpace(language))
                postParameters.Add("language", language);
            if (!string.IsNullOrWhiteSpace(type))
                postParameters.Add("type", type);
            if (!string.IsNullOrWhiteSpace(genre))
                postParameters.Add("genre", genre);
            if (!string.IsNullOrWhiteSpace(nogenre))
                postParameters.Add("nogenre", nogenre);
            if (!string.IsNullOrWhiteSpace(taggenre))
                postParameters.Add("taggenre", taggenre);
            if (!string.IsNullOrWhiteSpace(notaggenre))
                postParameters.Add("notaggenre", notaggenre);
            if (!string.IsNullOrWhiteSpace(fsk))
                postParameters.Add("fsk", fsk);
            if (!string.IsNullOrWhiteSpace(sort))
                postParameters.Add("sort", sort);
            if (!string.IsNullOrWhiteSpace(length))
                postParameters.Add("length", length);
            if (!string.IsNullOrWhiteSpace(lengthlimit))
                postParameters.Add("length-limit", lengthlimit);
            if (!string.IsNullOrWhiteSpace(tags))
                postParameters.Add("tags", tags);
            if (!string.IsNullOrWhiteSpace(tagratefilter))
                postParameters.Add("tagratefilter", tagratefilter);
            if (!string.IsNullOrWhiteSpace(limit))
                postParameters.Add("limit", limit);
            if (!string.IsNullOrWhiteSpace(page))
                postParameters.Add("p", page);
            if (!string.IsNullOrWhiteSpace(tagspoilerfilter))
                postParameters.Add("tagspoilerfilter", tagspoilerfilter);

            
            var request = CreateMessage(endPoint, postParameters);
            
            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<EntrySearch>(responseString);

            return result;
        }

        private HttpRequestMessage CreateMessage(string endPoint, Dictionary<string, string> parameters, bool testMode = false)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endPoint);
            
            if (string.IsNullOrWhiteSpace(ApiUserAgent))
            {
                throw new MissingUserAgentException("ApiUserAgent was not set.");
            }

            if (string.IsNullOrWhiteSpace(ApiKey))
                testMode = true;
            else
                request.Headers.Add("proxer-api-key", ApiKey);
            request.Headers.Add("User-Agent", ApiUserAgent);

            if (testMode)
                parameters.Add("api_testmode", "1");

            var encodedContent = new FormUrlEncodedContent (parameters);
            request.Content = encodedContent;

            return request;
        }
    }

    [System.Serializable]
    public class MissingUserAgentException : System.Exception
    {
        public MissingUserAgentException() { }
        public MissingUserAgentException(string message) : base(message) { }
        public MissingUserAgentException(string message, System.Exception inner) : base(message, inner) { }
        protected MissingUserAgentException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}