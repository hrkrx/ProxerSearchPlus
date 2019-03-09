namespace ProxerSearchPlus.model.v1
{
    public interface IApiResponse
    {
        Error GetError();
        int error { get; set; }
        int code { get; set; }
        string message { get; set; }
    }
}