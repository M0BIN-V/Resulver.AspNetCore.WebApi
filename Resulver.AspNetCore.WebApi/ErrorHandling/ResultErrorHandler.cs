using Resulver.AspNetCore.WebApi.ErrorHandling.Exeptions;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

internal class ResultErrorHandler : IResultErrorHandler
{
    readonly List<ResultErrorWithStatusCode> _errors;

    public ResultErrorHandler(List<ResultErrorWithStatusCode> errors)
    {
        _errors = errors;
    }

    public int GetErrorStatusCode(IResultError error)
    {
        foreach (var errorWithStatusCode in _errors)
        {
            if (error.GetType() == errorWithStatusCode.Error)
            {
                if (errorWithStatusCode.StatusCode == 0)
                {
                    throw new StatusCodeNotDefinedException();
                }

                return errorWithStatusCode.StatusCode;
            }
        }

        throw new ErrorNotHandledException(error.GetType().Name);
    }
}
