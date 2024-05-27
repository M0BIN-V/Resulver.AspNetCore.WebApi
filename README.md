### Table of content
- [Getting started](#getting-started)
    - [Installing](#1-Installing-package)
    - [Create result class](#2-Create-result-class)
    - [Usage](#3-Usage)
       - [Create controller](#Create-Controller)
       - [Error handler profiles]
       - [Use results as response]
       - [Result error handlers] 



## Getting started
### 1. Installing package
  ```bash
  dotnet add package Resulver.AspNetCore.WebApi
  ```


### 2. Create result class
 ```csharp
 public class MyResult : Result<string>
 {
      public MyResult(string content, string? message) : base(content, message) { }
 }
 ```
  In this case 'string' is result content type.
  
  You can change it to any other type you want.

  ## Usage
  ### 1. Create controller

  ```csharp
  using Microsoft.AspNetCore.Mvc;
  using Resulver.AspNetCore.WebApi;
  using Resulver.AspNetCore.WebApi.ErrorHandling;

  namespace MyApplication.Controllers;

  [ApiController]
  [Route("api/[controller]")]
  public class MyController : ResultBaseController
  {
      public MyController(IResultErrorHandler errorHandler) : base(errorHandler) {}
  }
  ```
