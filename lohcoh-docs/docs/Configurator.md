# Configurator

As I'm writing this I have an idea that lowkode could be tool for enabling modular, 
metadata-driven UI development and customization with the UI framework of your choice.

lowkode combines metadata from many sources and provides that metadata to your client application, where components use the metadata to render the user interface.
Further, the metadata can be customized via rules, enabling your UI to be heavily customized and extended in a productive, maintainable way.

Lowkode works with your current components, after adding lowkode to your project you can start using metadata to make your life easier.
Lowkode also provides a set of components specifically designed to make form creation *a lot* easier, check em out.

@T<DateComponent>(c => { c.Format= "MM/DD/YYYY"; c.Value= Order.ShippedDate; })

## Model-driven development

## Five types of 

## Things you can do with lowkode

	- Create a complete form with a single tag, just specify the type of object that you want to display.

	- Add an additional Report to the your application's Report menu for a specific client/tenant
		Uses: Uses: metadata(ui report contribution), context (client/tenant)

	- Add an extra field to a form when the current user belongs to specific Department.

	- Change the layout of your application's Employee form depending on the employee's Business Group, 
		since different Business Groups prioritize different information.

	- globally replace the component used to display dates
		Uses: metadata(component mapping), specification (component value type), and lowcode Placeholder utility.

	- use a custom Card component when displaying an Album in a Card and the Album won a Grammy.
		Uses: Uses: metadata(component mapping), specification (component value type, component value)

	- When displaying an Employee in a Form, make the SSN field optional when the client/tenant is not located in the US.
		Uses: Uses: metadata(Employee schema), context (client/tenant)

	- Display a status value from a database in a way that's meanful to an end-user.
		Uses: Uses: metadata(Enum schema definition that maps status values to view models), custom component for displaying status 

##

Idea...
Begin to promote lowkode, and get feedback on ideas, by publishing articles on model-driven development in ASP.NET Core.

Proposed Articles...

- Create a Model-Driven Form Component for Blazor using MVC Model Metadata
    Create a generic EditForm component that can display objects of a given type.
   
- Model-Driven Form Layout using MVC Model Metadata
    Use Attributes on your Models to automatically layout forms.

- Create a modular UI using MVC Model Metadata
    Create App with nav panel, create a library that adds WeatherForecasts to the UI.

- Customize UIs using MVC Model Metadata
    Add an extra field to an Order form for Customers from a specific state, without changing your code.

------------------------------------------
redundant...
    
- Create a Model-Driven Grid Component for Blazor using MVC Model Metadata 
    Create a generic DataGrid component that can display objects of a given type

- Create a Model-Driven Search Page ASP.NET Core ApiExplorer 

