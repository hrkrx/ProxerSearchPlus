namespace ProxerSearchPlus.model.v1
{
    public class EntrySearch : IApiResponse
    {
        public int error { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Entry[] data { get; set; }
    }
}