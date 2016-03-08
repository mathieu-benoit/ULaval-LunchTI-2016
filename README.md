# ULaval-LunchTI-2016

Document and demo code of our "LunchTI" for ULaval

1. Create an empty ASP.NET Core project with Visual Studio.
2. Configure the project to be a MVC project:
  * Create Models, Views and Controllers folders
  * Create associated basic Home* items: `HomeController.cs`, `HomeModel.cs` and `Home/Index.cshtml` files.
  * Install the Nuget package: `Install-Package Microsoft.AspNet.Mvc –Pre`
  * Configure Startup.cs with `services.addMvc()` and `app.useMvc()`
