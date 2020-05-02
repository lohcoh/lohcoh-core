# LowKode

## LowKode : Crazy productive form and table generator for Blazor

LowKode generates, assembles, and customizes UI elements.

Among other things, LowKode is used to...
- fully automate form creation, or just make your current forms easier to maintain.  
- automate the construction of grids and tables, menus, navigation, etc.
- keep business rules out of your UI code.

LowKode is the easiest way to build, customize, and extend a Blazor-based user interface for line of business applications.

LowKode is not a UI component library, it's a tool for composing UI elements, and generating new UI elements from an existing set of components.  
LowKode provides a basic set of UI components out of the box so that folks can be productive immediately, but you can 
configure LowKode to use whatever component library you have.

LowKode significantly reduces the efforst required to create basic UI components like forms, data tables, search panels, etc.  
LowKode contains an extensible metadata service that scans your application's 
artifacts and assemblies at startup, collects metadata, and provides that metadata to LowKode clients.
Then, LowKode uses this metadata to...
- map data, objects, and thier properties to UI components.
- create new UI elements for displaying data.
- customize UI elements based on business rules

LowKode can automatically provided many kinds of UI elements, including...
- full-featured forms 
- data tables 
- search forms
- navigation 
- signin form 
- permission based access to all UI elements, including navigation, forms, and search pages.
- User administration UI

Since LowKode is build with Blazor, LowKode's components can be used in your existing Razor Pages and MVC apps.


