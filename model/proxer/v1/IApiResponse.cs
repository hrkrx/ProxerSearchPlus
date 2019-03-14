namespace ProxerSearchPlus.model.proxer.v1
{
    public interface IApiResponse
    {
        Error GetError();
        int error { get; set; }
        int code { get; set; }
        string message { get; set; }
    }
}