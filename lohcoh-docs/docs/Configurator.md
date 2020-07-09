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
		- Doesn't necessarily require metadata, could use reflection directly.

	- Add an additional Report to the your application's Report menu for a specific client/tenant
		- Uses: Uses: metadata(ui report contribution), context (client/tenant)
		- Could be implemented simply by creating a component that accepts a list of reports, don't need lowkode

	- Add an extra field to a form when the current user belongs to specific Department.
		- Could be implemented with metadata, maybe, but that will cause mismatch with .NET reflection API.
		- In a perfect world, the server would return a subclass of the model object that contains the additional field.
			The UI would use the runtime type of the given model object and render the additional field.
			I guess it would be necessary to annotate types to inform lowkode what subclasses should be used for rendering.

	- Add two extra fields to a form, fields that represent data from other bounded contexts, 
		one field when the current user belongs to specific Department and another for a specific client/tenant.
		- With mixins.  I don't really see how this can be done with mixins.  
		- I think the answer is still that the UI would use the runtime type of the given model object and render the additional field.
			However, the modeling is different. I would create a view model that has the original model object plus all possible extensions as properties, 
			and use rules/context to hide/show extensions.

	- Change the layout of your application's Employee form depending on the employee's Business Group, 
		since different Business Groups prioritize different information.
		- could implement this with a rule-driven slot.
			This idea requires context.
		- could implement this by injecting layout into components, driven by configuration
		- could pass layout as a paremeter.
			How about rule-driven parameter injection??

	- Add Undo as a form extension
		Seems like this could be implemented by tapping into the EditContext.
		- Seems like rule-driven slots need a pipeline for assembling components

	- globally replace the component used to display dates
		Uses: metadata(component mapping), specification (component value type), and lowcode Placeholder utility.
		- could implement this with a rule-driven slot.

	- use a custom Card component when displaying an Album in a Card and the Album won a Grammy.
		Uses: Uses: metadata(component mapping), specification (component value type, component value)
		- could implement this with a rule-driven slot.

	- When displaying an Employee in a Form, make the SSN field optional when the client/tenant is not located in the US.
		Uses: Uses: metadata(Employee schema), context (client/tenant)

	- Display a status value from a database in a way that's meanful to an end-user.
		Uses: Uses: metadata(Enum schema definition that maps status values to view models), custom component for displaying status 

	- Customize components via event handling.  For instance, make InputText components select all text when the componet gains the focus.
		https://stackoverflow.com/questions/815797/add-dependency-property-to-control

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

