# ToDo

- Modify the default Blazor sample in the following ways...
	- Move the Counter Page to it's own project
		#### How is this implemented in a plain APS.NET Core app?
			- Need to register MVC AppPart in main Startup.cs, in ConfigureServices.
			- Need to declare Views folder as Embedded Resource in the Counter .csproj file.
			- Add the EmbeddedFileProvider to the RazorViewEngine, main Startup.cs, in ConfigureServices
		#### How should be implemented in a way that preserves proper Separation of Concerns?
			- the Counter project should have a Startup.cs file with a Startup class in it, and dot-featires-core 
			should call ConfigureServices method so that the Counter assembly can configure itself.
			NOTE: This could have been implemented with extension points.  So parts would declare themselves 
			and then MVC would assemble them.  But in the MVC word it seems that the standrad idiom is for 
			parts to declare themselves directly to a servfice.
			So maybe extension points are not really necessary.  An idiomatic .NET Core plugin system would be 
			designed so that modules register configuration services and other modules explicitly register 
			thier extensions using the Startup class.  

			The only thing that dot-features-core needs to implement is a service that calls the Startup class 
			in each assembly when it's loaded.

			Actually, dot-features-core doesn;t even have to do that much, 
			see [.NET Hosting Startup assemblies](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/platform-specific-configuration?view=aspnetcore-3.0).


	- Make the NavBar extensible

## What is dot-features-core?
dot-features-core is a library that makes it possible to compose .NET assemblies into applications.


## User Stories 

## Discovery


- Every project shoulde define a Module class, ala Angular.
The Module defines...
	- declarations: The 'excomponents, directives, and pipes that belong to this NgModule.

exports: The subset of declarations that should be visible and usable in the component templates of other NgModules.

imports: Other modules whose exported classes are needed by component templates declared in this NgModule.

providers: Creators of services that this NgModule contributes to the global collection of services; they become accessible in all parts of the app. (You can also specify providers at the component level, which is often preferred.)

bootstrap: The main application view, called the root component, which hosts all other app views. Only the root NgModule should set the bootstrap property.

