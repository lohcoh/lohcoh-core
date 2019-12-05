# lowcode

## lowcode : metadata driven, UI component library for ASP.NET.

lowcode is a Blazor-based, metadata driven, UI component library for ASP.NET.

lowcode eliminates the need to manually create basic UI elements like forms, data tables, search panels, etc.
Instead, lowcode can provide these UI elements using metadata from an augmented OpenApi/Swagger document.

lohcode's metadata-driven components can be used in your existing Razor Pages and MVC apps.
Conversely, lowcode can create a complete application UI and you can embed your existing Blazor components into lowcode's UI.

lowcode contains an extensible backend configration library that scans your application's artifacts and assemblies at startup and adds metadata to your OpenApi/Swagger document.
Developers can create thier own metadata-driven components by adding thier own metadata provider to the backend and creating UI components that leverage that metadata.

lowcode can automatically provided many kinds of UI elements, including...
- forms for editing, include validation
- data tables 
- search forms
- navigation 
- login form 
- permission based access to all UI elements, including navigation, forms, and search pages.
- User administration UI

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
- Personalization. Like in Airtable, make it possible for users to create and save thier own views.   
- Collaboration.  In addition to personalization, Like in PopSQL, make it possible to share your views with a team. 

#### components
A package of extended compoennts is probably the easiest to produce.

- High-level Patterfly-like components....
	- Filtered list.  [like this](https://www.capterra.com/order-management-software/)
	- <Kanban value=""> - [Displays Cards in a columnar display](https://airtable.com/images/home/kanban_view.png) where each column contains the cards in a particular status
	- <Calendar value=""> - [Displays a list of events in a calendar, with an optional list of the events](https://airtable.com/images/home/calendar_view.png) 
	- <Gallery value=""> - [Displays a list of cards in a grid](https://airtable.com/images/home/gallery_view.png) 


#### extensions
- admin panel
- User Admin extension for Lowco apps.
- SSO, and social login extension?

#### application blueprints
- Order management. https://www.zoho.com/us/inventory/order-management-software/
- Invoicing
- CMS extension for Lowco.  Grav-like
- CRM.  Like Composity or zoho
- Must at some point have workflow 
