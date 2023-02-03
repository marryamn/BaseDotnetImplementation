namespace Application.Common;

public class ResponseModel
{
    public int StatusCode { get; set; }
    public object? Data { get; set; }
    public string Message { get; set; }
}