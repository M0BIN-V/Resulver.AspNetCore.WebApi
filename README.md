### Table of content
- [Getting started](#getting-started)
    - [Installing](#1-Installing-package)
    - [Create controller](#2-Create-Controller)
       - [Error handler profiles]
       - [Use results as response]
       - [Result error handlers] 



## Getting started
### 1. Installing package
  ```bash
  dotnet add package Resulver.AspNetCore.WebApi
  ```
  ### 2. Create controller

  ```csharp
  [ApiController]
  [Route("api/[controller]")]
  public class MyController : ResultBaseController
  {
      public MyController(IResultErrorHandler errorHandler) : base(errorHandler) {}
  }
  ```
