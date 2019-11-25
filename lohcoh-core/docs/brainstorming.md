# lowco 

## Lowco : low code application development framework for .NET Core
It is possible, using GraphQL, ASP.NET Core, Entity Framework, and Blazor to create an application framework such that 
a developer need only define...
	- for the server: domain types and services
	- for the UI: view models

Lowco is a low-code application development framework for .NET Core developers.
With Lowco, a developer need only define domain types to create a complete, N-tier, web application.
Lowco applications are completely customizable 

The framework automatically provided all other layers and aspects of the application, including...
- database migrations
- repositories
- GraphQL API 
- User Interface with...
	- authentication 
	- navigation 
	- search forms
	- data tables
	- forms for editing
	- permission based access to all UI elements, including navigation, forms, and search pages.
	- User administration UI

### server...
- GraphQL queries are handled by the framework.
- GraphQL mutation are routed to controllers
- By default, CRUD mutations are handled by the framework but can be redirected to user-defind controllers
- metadata.  metadata is design time data that should be globally accessible.
	Contribution points are metadata.
	The GraphQL API exposes metadata inside the 'metadata' GraphQL root field

### client...
- All content display is type driven.  Uno uses tags like...
	- <Label value="@customer.Name">, <Label value="@customer">
	- <Editor value="@model">, <Editor value="@customer.Name">
	- <Form value="@model.FirstName">
	- <Card value="@model">
	- <Datagrid value="@customerList">
	- <Navigation value="@mainMenuItems"> - some components are populated by metadata contributions
These tags delegate to components that have been contributed to the system.
The justification for this tag scheme is threefold....
	- Avoids creating dependency on a particlar component library.
	- components can be easily replaced or customized.
	- Different contexts can be bound to different UIs.
	So, entire UI or compnents can be customized for client device, tenant, or user.
- Need CMS layout strategy.  Gridsome docs have a clear explanation of the UI system.
Visual Studio Code is an example of how contribution points should work.
- CSS: Use [Styled Components](https://www.styled-components.com/)

### monetizing

#### cross cutting extensions
- Personalization. Like in Airtable, make it possible to create your own views.   
- Collaboration.
	- In addition to personalization, Like in PopSQL, make it possible to share your views with a team. 

#### components
A package of extended compoennts is probably the easiest to produce.

- High-level Patterfly-like components....
	- Filtered list.  [like this](https://www.capterra.com/order-management-software/)
	- <Kanban value=""> - [Displays Cards in a columnar display](https://airtable.com/images/home/kanban_view.png) where each column contains the cards in a particular status
	- <Calendar value=""> - [Displays a list of events in a calendar, with an optional list of the events](https://airtable.com/images/home/calendar_view.png) 
	- <Gallery value=""> - [Displays a list of cards in a grid](https://airtable.com/images/home/gallery_view.png) 


#### extensions
- User Admin extension for Lowco apps.
- SSO, and social login extension?

#### application blueprints
- Order management. https://www.zoho.com/us/inventory/order-management-software/
- Invoicing
- CMS extension for Lowco.  Grav-like
- CRM.  Like Composity or zoho
- Must at some point have workflow 







## low code, headless, flat file, enterprise CMS for .NET Core Developers
olio is a modular, template-based development framework designed to eliminate the need to write any programming code, you just create content using codeless templates.
Create all kinds of content, components, and pages using our components and integrate it into your .NET Core with our content APIs.
Create forms, data tables, search pages, emails, blog entries, whatever.
Use our content API to get content in multiple formats; JSON, HTML, CSV, etc.
Integrate content into your own applications using olio's helper tags.

### Overview
olio is the fastest way to build your next web application.
olio provides powerful and convenient components to use in your templates that can display content the way you want it.
You can build your entire application in olio, or integrate your content into your own MVC, Razor Pages, or Blazor web application using olio's content API.

### Why .NET Core?
olio is lazer focused on the needs of .NET Core developers.
olio is built to take advantage of the types and services in your own application.
For instance, creating a form for editing a customer is just a single line in a template...
	<Olio.Editor For="nameof(MyCustomer)"/>
That's it, olio inspects the named type and dynamically creates a form.
olio leverages standrad .NET APIs, like DataAnnotations, to add validation and such.

### why flat files?
Flat file CMS's save all thier content in flat files in a folder instead of in a database.
Flat file CMS's have a lot of advantages, like not needing a database, but for developers the biggest advantage is version control.

### why a headess CMS?
Two reasons...
- Not every application that needs content is a web application.  For instance, a server process that sends a customer invoice to a customer.
- olio is a sophisicated piece of that might prove difficult to integrate into your application. 


### Why low code?
You have a lot of work to do, you can't get it done if you're spending your life writing code.
The rate of change in the development world is so fast that you can literally spend all your time learning the next framework instead of getting things done.
Put your content into olio and step off the hamster wheel.

### Why Enterprise?
Why not.  Other CMS's struggle with displaying domain objects  content because it's a lot of work to define domain types and how to display them.
olio can figure it all out from your .NET types and attributes. 


### Why


## low-code UI development tool for .NET Core 

Think 'embeddable admin panel'

Use brickette to visually create a wide variety of user interface elements that Blazor components.  From user input components and buttons to forms and dashboards.
Then reuse brickette components in your own applications.

- UI elements are driven by metadata stored in configuration files.
- brickette support roled-based and multi-tenant applications.  UI elements can be hidden, disabled, or replaced customized based on roles and tenant.
- In host application, brickette components connect to server


## The ultimate admin panel fo .NET applications
abp-console...

...is the ultimate adminstration portal for applications and services built with .NET Core. 
dot-admin has modules for all the backend functions within your company.
- customer support
	- Developers must add Nuget package
- User and Security management
- Techical development functions 
- Dashboard
- Reporting

The views built into dot-admin can be embedded into your own applications.

Compan

## What about an admin panel specifically designed for customer support?

This product is for use by developer, customer

The admin panel has features just for developers...
- create an admin panel from a Swagger spec.
- UI metadata saved in local database
- database schema is open source
- define custom views, and queries.  And share those views and queries with other developers.
- great way to promote metadata-driven UI.  This is essentially a CMS for enterprise apps.

## What about an admin panel specifically designed for developers?

This product is for use by developers to administrate an existing .NET Core application (create users, manage permissions) 
and 

The admin panel has features just for developers...
- create an admin panel from a Swagger spec.
- UI metadata saved in local database
- database schema is open source
- define custom views, and queries.  And share those views and queries with other developers.
- great way to promote metadata-driven UI.  This is essentially a CMS for enterprise apps.

## What about an admin panel specifically designed for businesses?
- Same as above but users must create entity and view objects.
- Customize views based on roles
- Includes basic workflow features.

## What about a low-code development tool JUST for the UI?????  And just for Blazor???

Many companies might like to migrate to Blazor...
	- to reduce their technical debt by reducing the # of technologies in thier stack
	- to make it possible to creating more compelling and advanced UIs than they can with thier current stack

Blazor presents an opportunity for a new kind of UI tool...

- Tool must be 
- Always start by creating a new application.
- Customize basic structure: navigation, app header/footer, logo etc.
- Generates UIs for existing C# types 
- Define new Entity type and Views
- Use Swagger spec to connect to REST API?
- Create simple single-endpoint connector for queries?
- 

## brainstorm

### Other ideas

- Graphical command console for .NET developers

### is abp-console a code generator, command console (graphical or not) or admin panel?
The orignal goal was to reproduce the success of [QuickAdminPanel]() for abp.io apps.  
QuickAdminPanel si a graphical code generator.
So graphical code generator.
NOTE:  ABPNetZero is a framework (abp.io) and graphical code generator 


	
- VS and VS Code editor extensions that hide 'features' in code.

### interacting with database at design time

idea: design time tool could connect to databases and services defined in the project by dynamically 
  loading and running the project's assemblies.  So, for 