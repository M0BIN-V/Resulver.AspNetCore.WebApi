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
            Error = result.Errors.ConvertAll(e => new ResultErrorResponse()
            {
                ErrorName = e.GetType().Name,
                Message = e.Message,
            })
        };
    }

    public static ResponseBodyTemplate Build(IResult result)
    {
        return new ResponseBodyTemplate
        {
            Message = result.Message,
            Error = result.Errors.ConvertAll(e => new ResultErrorResponse()
            {
                ErrorName = e.GetType().Name,
                Message = e.Message,
            })
        };
    }

    public static ResponseBodyTemplate<TContent> ToResponseBody<TContent>
        (this IResult<TContent> result) => Build(result);

    public static ResponseBodyTemplate ToResponseBody(this IResult result) => Build(result);
}
