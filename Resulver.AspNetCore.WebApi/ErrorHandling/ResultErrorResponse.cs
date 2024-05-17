namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ResultErrorResponse
{
    public required string ErrorName { get; set; }
    public string? Message { get; set; }
}
