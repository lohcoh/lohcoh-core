# How lowkode works

At it's core LowKode is pretty simple....  
- During development, developers write code, using the Lowkode Fluent Metadata API, to configure LowKode with metadata 
that LowKode UI components will use to render UI elements, metadata like display labels and validation rules.  
The Fluent API is also used to map data and object types to UI elements.
- At Startup, lowKode gathers metadata from a variety of source and puts the data into the 
	LowKode MetaData Service.  
- Then later, when a LowKode Blazor component is used in a template, the component uses metadata 
	to generate some content.




