using Resulver.AspNetCore.WebApi.ErrorHandling;

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
            new ErrorResponse
            {
                ErrorName = result.Error!.GetType().Name,
                Message = result.Error.Message,
            } : null
        };
    }
}
