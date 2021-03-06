# Quick Start

In this section we will recreate the Weather create a basic form for displaying a Customer.
Then we'll add validation and required field decorations to the form without writing code.
And then we'll improve the layout the form, again without writing any code.
We'll start with this C# definition of a Customer...

class Customer 


### Blazor templates
To get started, we need to create a Blazor template 


## lowkode Templates





lowkode contains an extensible backend configuration library that scans your application's 
artifacts and assemblies at startup and adds metadata to your OpenApi/Swagger document.
In the browser, lowkode uses this metadata to assemble a custom UI.
Developers can create thier own metadata-driven components by adding thier own metadata provider to the backend and creating UI components that leverage that metadata.

### client...
- All content display is type driven.  examples...
	- <EditForm forType=@typeof(Customer) value=@customer/>  
		This displays an entire form for editing a Customer
	- <Card forType=@typeof(Customer) value=@customer/>  
		Displays a view-only, abbreviated view of a Customer
	- <DisplayTable forType=@typeof(Customer) value="@customerList">
		Displays a view-only table of customers
	- <Navigation forType=@typeof(NavigationMenuItem) value="@mainMenuItems"> 
		Some components are populated by metadata contributions

These tags delegate to components that have been contributed to the system.
The justification for this tag scheme is threefold....
	- Avoids creating dependency on a particlar component library.
	- component implementations can be easily replaced or customized.
	- Different contexts can be bound to different UIs.
	So, entire UI or subsets of components can be customized for client device, tenant, or user.
- Need CMS layout strategy.  Gridsome docs have a clear explanation of the UI system.
Visual Studio Code is an example of how contribution points should work.
- CSS: Use [Styled Components](https://www.styled-components.com/)

### monetizing

#### cross cutting extensions 
- Personalization. Like in Airtable, make it possible for users to create and save thier own views.   
- Collaboration.  In addition to personalization, like in PopSQL, make it possible to share your views with a team. 

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



## names

I kinda like 'lowkode'.
I like that when you google lowkode it displays dome results for 'low-code'

### Available
loecode
lowkode
lokoh
locoh

### Taken
loco
lokode
locode


