namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorResponse
{
    public required string ErrorName { get; set; }
    public string? Message { get; set; }
}
