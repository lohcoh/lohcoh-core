# How lowkode works

LowKode generates, assembles, and customizes UI elements from a set of base Components, Metadata, Rules, and runtime Context.
LowKode's primary functions are to...
- map types and thier properties to UI components.  
- Use metadata to create new UI elements for displaying data.
- customize UI elements based on business rules



A LowKode application is comprised of...

- One or more libraries of basic UI Components
	LowKode is not a UI component library, it's a tool for composing UI elements, and generating new UI elements, from an existing set of components.  
	LowKode provides a basic set of UI elements out of the box so that folks can be productive immediately.  
	You can configure LowKode to use whatever components you have, using the LowKode configuration service.

- A repository of Metadata.
	At Startup, LowKode is configured with metadata from a variety of sources and saves this data in a metadata repository.  
	Metadata includes schemas for objects, component mappings, available web services, UI contributions, etc.  
	LowKode can be extended with custom metadata providers.
	Clients use Linq queries to 
	Examples of what can be done with Metadata...  
	- globally replace the component used to display dates
	- Generate a full featured form for displaying an Employee
	- Generate a full featured table for displaying search results
	- Generate a menu for displaying all available reports.

- A repository of Rules
	Rules modify metadata, usually based on runtime Context values.
	Rules are configured at Startup.
	Examples of what can be done with Rules...
	- use a custom Card component when displaying an Album in a Card and the Album won a Grammy.
	- Add an additional Report to the Report menu for a specific tenant.
	- When displaying an Employee in a Form, make the SSN field optional when the Employee belongs to a business unit that's not located in the US.

- A Context object.
	A Context is a collection of key/value pairs that describe any runtime aspects of the current application needed to create a customized component.
	A value that identifies the current User is a common value to include in a Context.  
	A LowKode application contains a single Context object that is shared among all components in an application.  
	Context values are most often used by Rules to customize a UI with business rules.  

- One or more libraries of LowKode templated Components
	LowKode does include some components of it's own, these are the components that fulfill it's primary functions, to map objects and properties 
	to components and to generate new UI elements.
	For instance...  
	- Using metadata, the <EditFields> component automagically generates editable field templates for every property in an object.
	- Using metadata, the <DisplayFields> component automagically generates read-only field templates for every property in an object.
	- The <Editor> component maps a data element to a UI component that can edit the data.
	- The <Display> component maps a data element to a UI component that displays the data in a read-only mode.






