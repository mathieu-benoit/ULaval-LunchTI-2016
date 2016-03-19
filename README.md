# ULaval-LunchTI-2016

Documentation and demo code of our "LunchTI" for ULaval by exploring the new world of ASP.NET Core 1.0 (RC1).

**C# | ASP.NET Core 1.0 (RC1) | MVC 6 | Entity Framework 7 | xUnit | Swagger | Dependency Injection | Visual Studio Community 2015 | Web API | Linux | Azure | Bootstrap | Gulp**

Here is the [support of our presentation](https://github.com/nurunquebec/ULaval-LunchTI-2016/blob/master/Universit%C3%A9%20Laval%202016%20-%20Microsoft%20et%20le%20d%C3%A9veloppement%20web%20moderne.pdf) [fr].

Here is the step-by-step (and more) of our demo:
### 1. Create an empty **ASP.NET Core** project with **Visual Studio Community** 2015 [c6f337b](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/c6f337b2d067462878685ae5dc3be5ec1f263750)

### 2. Configure the project to use **MVC 6** [fd9e8fe](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/fd9e8feafa7a75a1ceee942c418c08a0e04c7fa5)
  * Create Models, Views and Controllers folders
  * Create associated basic Home* items: `HomeController.cs`, `HomeModel.cs` and `Home/Index.cshtml` files.
  * Install the Nuget package: `Install-Package Microsoft.AspNet.Mvc –Pre`
  * Configure `Startup.cs` with `services.addMvc()` and `app.useMvc()`.

### 3. Configure the project to use **Entity Framework 7**
  * Install the Nuget packages: `Install-Package EntityFramework.Core –Pre` amd `Install-Package EntityFramework.MicrosoftSqlServer –Pre`
  * TODO

### 4. TIPS: Add the error details page [8baa57a](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/8baa57a00d5ec319d2e0f324ff6e5b949a18bb55)
  * Install the Nuget package: `Install-Package Microsoft.AspNet.Diagnostics -Pre`
  * Configure `Startup.cs` with `app.UseDeveloperExceptionPage()`.

### 5. Generate scaffolding items
  * Install the Nuget packages: `Install-Package Microsoft.Extensions.CodeGenerators.Mvc –Pre` and `Install-Package Microsoft.AspNet.Mvc.TagHelpers -Pre`.
  * TODO

### 6. TIPS: Add the **Static Files** to allow access and use of css and javascript files
  * Reference: [Working with Static Files](https://docs.asp.net/en/latest/fundamentals/static-files.html)
  * Install the Nuget package: `Install-Package Microsoft.AspNet.StaticFiles -Pre`
  * Configure `Startup.cs` with `app.UseStaticFiles()`.

### 7. Generate a scaffolding **WebAPI** with MVC 6 [85ea32c](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/85ea32c83798fde67d70be49a33e2a61ea81b962)
  * Right click on the `Controllers` folder, click on "Add" and then on "Controller..." and choose "API Controller with actions, using Entity Framework".
  * Fill out the information to create a new `TodoItemsApiController` with the `TodoItemsModel` as "Model class" and `ULavalLunchTiContext` as "Data context class".
  * Go to the generated file to see how to get the list of the items, one specific item, etc.

### 8. TIPS: Add the **Swagger** addin to provide a documentation to your web services [69ab7ae](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/69ab7ae62db74066fbfa08d8246f209e6807241c)
  * Install the Nuget package: `Install-Package Swashbuckle -Pre`
  * Configure `Startup.cs` with `services.AddSwaggerGen()`, `app.UseSwaggerGen()` and `app.UseSwaggerUi()`.

### 9. TIPS: Add the **Glimpse** addin to have real time diagnostics and insights [48ecd3b](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/48ecd3bfc47858da3b48e0138592c981c3868ea3)
  * Reference: [Glimpse](http://getglimpse.com/)
  * Install the Nuget package: `Install-Package Glimpse -Pre`
  * Configure `Startup.cs` with `using Glimpse`, `services.AddGlimpse()` and `app.UseGlimpse()`.

### 10. Create a unit test project with **xUnit** [266f515](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/266f5151b256c178b114e6ab1ed1cbf476af4770)
  * Reference: [Getting Started with xUnit.net - DNX / ASP.NET 5](http://xunit.github.io/docs/getting-started-dnx.html)
  * Create a new Class Library and modify the `project.json` by changint the `frameworks`entry with `dnx451` and `dnxcore50`
  * Install the Nuget packages: `Install-Package xunit -Pre`and `nstall-Package xunit.runner.dnx -Pre`
  * With that you will be able to create and run your first unit test (Test Explorer window in Visual Studio).
  * TIPS: you could add in the `commands`entry of the `project.json` this line `"test": "xunit.runner.dnx"` to excute this command line: `dnx test`.

### 11. Implement a **Dependency Injection (DI)**
  * Reference: [Dependency Injection](https://docs.asp.net/en/latest/fundamentals/dependency-injection.html)
  * ASP.NET 5 is designed to leverage built-in DI. Some Framework-Provided Services are already exposed during our demo, for example by using `services.AddEntityFramework()` or `services.AddMvc()`.
  * But you can register your own services like shown in this commit [767bbcf](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/767bbcf4532e3425632def515a0e732387018f17)

### 12. Work with **Multiple Environments** [c75b9aa](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/c75b9aa1c6e2dee3c72446bbda4472c58078c85f)
  * Reference: [Working with Multiple Environments](https://docs.asp.net/en/latest/fundamentals/environments.html)
  * Configure `Startup.cs` with the new parameter `IHostingEnvironment` of the `Configure` method and then you are able to use `env.IsDevelopment()`, `env.IsStaging()` or `env.IsProduction()`
  * TIPS: you could also use the `<environment>` tag helper on any cshtml [5ad0b79](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/5ad0b79c4d7a6393fa9e4a056f44b9c9ce042f71) or [2b02f6a](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/2b02f6a7beeaf48df60d265cf36b013516997400)

### 13. Use **Gulp** to minify and bundle *.css and *.js files [2b02f6a](https://github.com/nurunquebec/ULaval-LunchTI-2016/commit/2b02f6a7beeaf48df60d265cf36b013516997400)
  * Reference: [Using Gulp](http://docs.asp.net/en/latest/client-side/using-gulp.html)
  * Add ```gulpfile.js``` to manage gulp tasks and ```package.json``` to manage javascript packages.
  * In Visual Studio you can interact with the tasks defined with the window "Task Runner Explorer".

### 14. Deploy your web app on **Linux**
  * TODO

### 15. Deploy your web app in **Azure**
  * TODO

