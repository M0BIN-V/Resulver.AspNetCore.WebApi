[![NuGet Package](https://img.shields.io/nuget/v/Resulver.AspNetCore.WebApi)](https://www.nuget.org/packages/Resulver.AspNetCore.WebApi/)



### Table of content
- [Installation](#Installation)
- [Error Handling](#Error-Handling)
- [Using in Controllers](#Using-in-Controllers)
## Installation
  ```bash
  dotnet add package Resulver.AspNetCore.WebApi
  ```

## Error Handling

### 1. First, add the following code to the Program.cs file:

```csharp
builder.Services.AddErrorProfilesFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddErrorResponseGenerator();
```

### 2. Create Error Profiles
In this example, we have created an error named ValidationError :
```csharp
public class ValidationError(string title, string message) : ResultError(message, title: title)
{

}
```
Now, to manage responses related to this error, we will create a profile for it.

```csharp
public class ValidationErrorProfile : ErrorProfile
{
    public ValidationErrorProfile()
    {
        AddError<ValidationError>().WithStatusCode(400);
    }
}
```
Additionally, to customize the responses, you can use the HandleWith() method :
```csharp
public class ValidationErrorProfile : ErrorProfile
{
    public ValidationErrorProfile()
    {
        AddError<ValidationError>()
            .HandleWith(error =>
            {
                var response = new
                {
                    errorName = "validation problem",
                    errorMessage = error.Message
                };

                return new ObjectResult(response) { StatusCode = 400 };
            });
    }
}
```

## Using in Controllers
### You can use the following methods to utilize IResultHandler in your Controllers :
#### Method 1: Inheritance from the ResultBaseController class : 
```csharp
[ApiController]
[Route("api/[controller]")]
public class MyController : ResultBaseController
{
    [HttpGet]
    public IActionResult AddUser()
    {
        // logic
        //
        //

        var result = new Result("User Added");

        //use default 200 status code
        return FromResult(result);

        //or
        //use custom status code
        return FromResult(result, 200);

        //or
        //use customized result
        return FromResult(result, () => CreatedAtRoute("ExampleRouteName", result.Message));
    }
}
```
Note: In all cases, if the Result contains an error, a response will be generated based on the error profile created for that error.
#### Method 2: Inject IErrorResponseGenerator in to your controller:
```csharp
[ApiController]
[Route("api/[controller]")]
public class MyController : ControllerBase
{
    readonly IErrorResponseGenerator _errorResponseGenerator;

    public MyController(IErrorResponseGenerator errorResponseGenerator)
    {
        _errorResponseGenerator = errorResponseGenerator;
    }

    [HttpGet]
    public IActionResult AddUser()
    {
        // logic
        //
        //

        var result = new Result("User Added");

        if (result.IsFailure)
        {
            return _errorResponseGenerator.MakeResponse(result.Errors[0]);
        }

        else return Ok(result.Message);
    }
}
```

