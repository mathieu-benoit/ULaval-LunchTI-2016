# ULaval-LunchTI-2016

Document and demo code of our "LunchTI" for ULaval

1. Create an empty ASP.NET Core project with Visual Studio.
2. Configure the project to use MVC 6:
  * Create Models, Views and Controllers folders
  * Create associated basic Home* items: `HomeController.cs`, `HomeModel.cs` and `Home/Index.cshtml` files.
  * Install the Nuget package: `Install-Package Microsoft.AspNet.Mvc –Pre`
  * Configure `Startup.cs` with `services.addMvc()` and `app.useMvc()`
3. Configure the project to use Entity Framework 7:
  * Install the Nuget packages: `Install-Package EntityFramework.Core –Pre` amd `Install-Package EntityFramework.MicrosoftSqlServer –Pre`
  * TODO
4. TIPS: Add the error detasils page
  * Install the Nuget package: `Install-Package Microsoft.AspNet.Diagnostics -Pre`
  * Configure `Startup.cs` with `app.UseDeveloperExceptionPage()`
5. Generate scaffolding items
  * Install the Nuget package: `Install-Package Microsoft.Extensions.CodeGenerators.Mvc –Pre`
  * TODO
6. TIPS: Add the TagHelper
  * TODO
7. TIPS: Add the staticfiles
  * TODO
8. Create a WebAPI with MVC 6
  * TODO
9. TIPS: Add the Swagger addin
  * TODO
10. TIPS: Glimpse
  * TODO
11. xUnit
  * TODO
12. Linux
  * TODO

