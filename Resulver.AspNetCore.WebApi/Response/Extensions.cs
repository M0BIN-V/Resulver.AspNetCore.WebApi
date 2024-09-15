namespace Resulver.AspNetCore.WebApi.Response;

public static class Extensions
{
    public static ResponseTemplate ToResponseTemplate(this Result result)
    {
        return new ResponseTemplate
        {
            Message = result.Message,
        };
    }

    public static ResponseTemplate ToResponseTemplate<TContent>(this Result<TContent> result)
    {
        return new ResponseTemplate<TContent>
        {
            Message = result.Message,
            Content = result.Content,
        };
    }
}
