using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProxerSearchPlus.Caching;
using ProxerSearchPlus.Caching.Database;
using ProxerSearchPlus.Model.Proxer.v1;
using System.Linq;
using System.Collections;

namespace ProxerSearchPlus.Controller.Proxer.v1
{
    public class ApiClient
    {
        private static ApiClient instance; 
        private HttpClient client { get; set; }

        public string ApiKey { get; set; }

        public string ApiUserAgent { get; set; }

        public IDatabaseConnection DatabaseConnection { get; set; }

        private ApiClient(IDatabaseConnection dbConnection)
        {
            DatabaseConnection = dbConnection;
            client = new HttpClient();
        }

        public static ApiClient GetInstance(IDatabaseConnection dbConnection)
        {
            if (instance == null)
            {
                instance = new ApiClient(dbConnection);
            }
            return instance;
        }

        /// <summary>
        /// This method returns a full entry for a given id while using as much from the cache as possible
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="doNotUseCache">if you want to load everything from Proxer, ignoring the cache. WARNING: Do not use this regularly</param>
        /// <returns>A full entry from Proxer</returns>
        public async Task<FullEntry> GetFullEntry(int id, bool doNotUseCache = false)
        {
            var fullEntryEndPoint = "https://Proxer.me/api/v1/info/fullentry";
            var entryEndPoint = "https://Proxer.me/api/v1/info/entry";
            FullEntry result;

            var postParameters = new Dictionary<string, string>();

            if (id > 0)
               postParameters.Add("id", id.ToString());

            if (doNotUseCache) // insert Spongebob Meme
            {
                result = await GetData<FullEntry>(postParameters, fullEntryEndPoint);
            }
            else
            {
                // Database stuff for enablin the cache
                var dbResult = DatabaseConnection.Get(id, typeof(EntryDetail)).Cast<EntryDetail>();
                if (dbResult.Any())
                {
                    result = new FullEntry();
                    result.data = dbResult.First();
                    result.code = 1;
                }
                else
                {
                    result = await GetData<FullEntry>(postParameters, entryEndPoint); 
                    DatabaseConnection.Put(result.data);                                   
                }
            }
            
            return result;
        }


        public async Task<EntrySearch> Search(string name)
        {
            return await Search(name, null, null, null, null, null, null, null, null, null, null, null, null, "10", null, null);
        }

        /// <summary>
        /// Returns a list of "limit" entries for your input parameters
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="language">The Language (de, en, ...)</param>
        /// <param name="type">The type (anime, manga, ...)</param>
        /// <param name="genre">The genre</param>
        /// <param name="nogenre"></param>
        /// <param name="taggenre"></param>
        /// <param name="notaggenre"></param>
        /// <param name="fsk"></param>
        /// <param name="sort"></param>
        /// <param name="length"></param>
        /// <param name="lengthlimit"></param>
        /// <param name="tags"></param>
        /// <param name="tagratefilter"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <param name="tagspoilerfilter"></param>
        /// <returns></returns>
        public async Task<EntrySearch> Search(string name, string language, string type, string genre, string nogenre, 
                                                string taggenre, string notaggenre, string fsk, string sort, string length, 
                                                string lengthlimit, string tags, string tagratefilter, string limit,
                                                string page, string tagspoilerfilter)
        {
            var endPoint = "https://Proxer.me/api/v1/list/entrysearch";
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
            
            result = await GetData<EntrySearch>(postParameters, endPoint);
            return result;
        }
        /// <summary>
        /// Creates a sendable message 
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="parameters">post parameters to be included in the body</param>
        /// <param name="testMode">if testmode is enabled no apikey is required</param>
        /// <returns></returns>
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
                request.Headers.Add("Proxer-api-key", ApiKey); 
            request.Headers.Add("User-Agent", ApiUserAgent);

            if (testMode)
                parameters.Add("api_testmode", "1");

            var encodedContent = new FormUrlEncodedContent (parameters);
            request.Content = encodedContent;

            return request;
        }

        /// <summary>
        /// Executes a request to an entrypoint with the given data and returns an object
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="endPoint"></param>
        /// <typeparam name="T">The Type of the object to be returned (e.g. EntrySearch)</typeparam>
        /// <returns>an object of type T</returns>
        public async Task<T> GetData<T>(Dictionary<string, string> postData, string endPoint)
        {
            T result;
            using(var request = CreateMessage(endPoint, postData))
            {
                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(responseString);
            }
            return result;
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