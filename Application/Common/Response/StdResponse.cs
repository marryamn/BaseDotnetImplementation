using System.Net;

namespace Application.Common.Response;

public class StdResponse<TValue>
{
    protected internal StdResponse(HttpStatusCode status = HttpStatusCode.OK, string? message = null,
        object? data = default)
    {
        Status = status;
        Message = message;
        Data = data;
    }
    public string? Message { get; set; }
    public HttpStatusCode Status { get; set; }
    public object? Data { get; set; }
}