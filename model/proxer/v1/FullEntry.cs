namespace ProxerSearchPlus.model.proxer.v1
{
    public class FullEntry : IApiResponse
    {
        public int error { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public EntryDetail data { get; set; }

        public Error GetError()
        {
            throw new System.NotImplementedException();
        }
    }
}