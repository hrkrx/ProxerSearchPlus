namespace ProxerSearchPlus.Model.Proxer.v1
{
    public interface IApiResponse
    {
        Error GetError();
        int error { get; set; }
        int code { get; set; }
        string message { get; set; }
    }
}