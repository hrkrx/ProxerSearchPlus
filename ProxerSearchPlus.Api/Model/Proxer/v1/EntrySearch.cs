using System.Linq;
using ProxerSearchPlus.Api.Caching;

namespace ProxerSearchPlus.Api.Model.Proxer.v1
{
    [Cacheable]
    public class EntrySearch : IApiResponse
    {
        public int error { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Entry[] data { get; set; }

        public Error GetError()
        {
            return new Error(error);
        }

        public override string ToString()
        {
            string result = string.Join("\n", data.Select(x => x.ToString()).ToList());
            result += "\n" + GetError();
            return result;
        }
    }
}