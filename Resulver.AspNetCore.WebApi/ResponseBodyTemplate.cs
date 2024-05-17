using Resulver.AspNetCore.WebApi.ErrorHandling;

namespace Resulver.AspNetCore.WebApi;

public class ResponseBodyTemplate<TContent>
{
    public ResultErrorResponse? Error { get; set; }
    public string? Message { get; set; }
    public TContent? Content { get; set; }
}
