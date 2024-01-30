namespace JeBalance.UI.Data.Services.Error;

public class RequestResult<T>
{
    public RequestResult(T? result)
    {
        Result = result;
    }

    public RequestResult(string? errormessage)
    {
        Errormessage = errormessage;
    }

    public T? Result { get; set; }
    public string? Errormessage { get; set; }
}