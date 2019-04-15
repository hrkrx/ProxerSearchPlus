namespace ProxerSearchPlus.Model.Proxer.v1
{
    public class FullEntry : IApiResponse
    {
        public int error { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public EntryDetail data { get; set; }

        public Error GetError()
        {
            return new Error(error);
        }

        public override string ToString()
        {
            string result = data.ToString();
            result += "\n" + GetError();
            return result;
        }
    }
}