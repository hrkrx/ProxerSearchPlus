namespace ProxerSearchPlus.model.v1
{
    public interface IApiResponse
    {
        int error { get; set; }
        int code { get; set; }
        string message { get; set; }
        Entry[] data { get; set; }
    }
}