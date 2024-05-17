﻿using Resulver.AspNetCore.WebApi.ErrorHandling.Exeptions;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

internal class ErrorHandler : IErrorHandler
{
    readonly List<ErrorWithStatusCode> _errors;

    public ErrorHandler(List<ErrorWithStatusCode> errors)
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
