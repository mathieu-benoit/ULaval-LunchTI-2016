# ULaval-LunchTI-2016

**C# | ASP.NET Core 1.0 | MVC 6 | xUnit | Swagger | IoC | Visual Studio Community 2015 | Web API | Linux | Azure | Bootstrap | Gulp**

Document and demo code of our "LunchTI" for ULaval

1. Create an empty **ASP.NET Core** project with **Visual Studio Community** 2015 [c6f337b](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/c6f337b2d067462878685ae5dc3be5ec1f263750)
2. Configure the project to use **MVC 6** [fd9e8fe](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/fd9e8feafa7a75a1ceee942c418c08a0e04c7fa5)
  * Create Models, Views and Controllers folders
  * Create associated basic Home* items: `HomeController.cs`, `HomeModel.cs` and `Home/Index.cshtml` files.
  * Install the Nuget package: `Install-Package Microsoft.AspNet.Mvc –Pre`
  * Configure `Startup.cs` with `services.addMvc()` and `app.useMvc()`
3. Configure the project to use **Entity Framework 7**
  * Install the Nuget packages: `Install-Package EntityFramework.Core –Pre` amd `Install-Package EntityFramework.MicrosoftSqlServer –Pre`
  * TODO
4. TIPS: Add the error details page
  * Install the Nuget package: `Install-Package Microsoft.AspNet.Diagnostics -Pre`
  * Configure `Startup.cs` with `app.UseDeveloperExceptionPage()`
5. Generate scaffolding items
  * Install the Nuget packages: `Install-Package Microsoft.Extensions.CodeGenerators.Mvc –Pre` and `Install-Package Microsoft.AspNet.Mvc.TagHelpers -Pre`
  * TODO
6. TIPS: Add the **staticfiles** to allow access and use of css and javascript files
  * Install the Nuget package: `Install-Package Microsoft.AspNet.StaticFiles -Pre`
  * Configure `Startup.cs` with `app.UseStaticFiles()`
7. Generate a scaffolding **WebAPI** with MVC 6
  * Right click on the `Controllers` folder, click on "Add" and then on "Controller..." and choose "API Controller with actions, using Entity Framework".
  * Fill out the information to create a new `TodoItemsApiController` with the `TodoItemsModel` as "Model class" and `ULavalLunchTiContext` as "Data context class".
  * Go to the generated file to see how to get the list of the items, one specific item, etc.
8. TIPS: Add the **Swagger** addin to provide a documentation to your web services
  * Install the Nuget package: `Install-Package Swashbuckle -Pre`
  * Configure `Startup.cs` with `services.AddSwaggerGen()`, `app.UseSwaggerGen()` and `app.UseSwaggerUi()`
9. TIPS: Add the **Glimpse** addin
  * TODO
10. **xUnit**
  * TODO
11. **Linux**
  * TODO
12. **Azure**
  * TODO

