using Resulver.AspNetCore.WebApi.ErrorHandling;
using System.Runtime.CompilerServices;

namespace Resulver.AspNetCore.WebApi;

public static class ResponseBodyTemplateBuilder
{
    public static ResponseBodyTemplate<TContent> Build<TContent>(
        IResult<TContent> result)
    {
        return new ResponseBodyTemplate<TContent>
        {
            Content = result.Content,
            Message = result.Message,
            Error = result.IsFailure ?
            new ResultErrorResponse
            {
                ErrorName = result.Error!.GetType().Name,
                Message = result.Error.Message,
            } : null
        };
    }

    public static ResponseBodyTemplate<TContent> ToResponseBody<TContent>
        (this IResult<TContent> result)
    {
        return Build(result);
    }
}
