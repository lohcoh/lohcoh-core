# lohcode

lohcode is a low-code application development framework that reduces the effort required to build, maintain, customize, and extend business applications.

lohcode is essentially a ready to go, ASP.NET Core 'application in a box' that is extremely customizable and extensible.

lohcode acheives radical levels of reuse, customization, and extensibility by being based on a metamodel.
The metamodel defines all the architectural parts of the application.
lohcode provides implementations for most parts of the metamodel, a developer implements just some of the parts. 

A developer need only add some domain types and some business logic and lohcode can supply the rest of the application...
- Migrations for creating and maintaining your database (for Entity Framework)
- Repositories for accessing data.
- Transaction Management
- REST and GraphQL APIs
- Online Swagger Documentation
- Client-side service proxies
- Complete, full-featured, forms that are completely customizable with your own templates
- Completely customizable Blazor-based UI.
- Application Bus and Domain Events

How does lohcode do this?  
Most ASP.NET applications contain a ton of 'plumbing' code, code that just wires together all the parts of an application.  
In fact, most small applications are mostly just plumbing code.  
lohcode eliminates the boilerplate by automatically discovering, and wiring up all the architecturre elements of your app 
and dynamically constructing many missing elements.

lohcode's metamodel is the source of the magic that makes it possible to automatically wire together third-party frameworks without 
requiring the develop to write code to do it.  
The metamodel also makes it possible for lohcode to discover and inspect the architectural elements of the system, thus making it possible 
for lohcode to do things like...
- dynamically generate a form for editing an entity and connect that form to the backend application services.
- automatically provide REST and GraphQL APIs for your application
- automatically connect your entities to Entity Framework and create migrations

The metamodel also makes it possible to replace any of the applications parts in a straightforward way.
Want to use Dapper instead of Entity Framework?  Just use a different Nuget package.

lohcode isn't some giant framework that you'll spend months or years mastering.
lohcode is a thin layer over the ASP.NET Core APIs, if you are an ASP.NET developer you will continue to use the APIs that you already know.

lohcode is not bound to a particular metamodel.
You can extend lohcode's default model or create a new one.
lohcode's default metamodel defines a basic architecture based on Domain-Driven Design Principles.











