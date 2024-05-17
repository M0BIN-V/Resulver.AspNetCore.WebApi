using Resulver.AspNetCore.WebApi.ErrorHandling;

namespace Resulver.AspNetCore.WebApi;

public class ResponseBodyTemplate<TContent>
{
    public ErrorResponse? Error { get; set; }
    public string? Message { get; set; }
    public TContent? Content { get; set; }
}
