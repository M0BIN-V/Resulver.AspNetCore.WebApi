using Resulver.AspNetCore.WebApi.ErrorHandling;

namespace Resulver.AspNetCore.WebApi;

public class ResponseBodyTemplate
{
    public List<ResultErrorResponse> Error { get; set; } = [];
    public string? Message { get; set; }
}

public class ResponseBodyTemplate<TContent> : ResponseBodyTemplate
{
    public TContent? Content { get; set; }
}