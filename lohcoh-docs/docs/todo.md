# ToDo

## Design of context and metadata API
It's been difficult to design the context and metadata APIs.
I don't have a good solution for APIs that need to be extensible by third-parties, and typesafe.
Here's what I've decided so far...
...Context will be defined by custom classes, like with React Context.
...Context will be injected into components using a parameter with a [ContextParameter] attribute, like with Cascading parameters in Blazor.
...Context containers will form a nested hierarchy, one container per component.
	When a context container does not contain a vaue requested by a component then it will delegate to it's parent container, 
	unless the specified item has been explicitly removed from the child container.
...Metadata will be modeled after a database, using 'records' of a given type.
	Query facilities will be limited.
	This approach will make it easier to customize metadata will rules.
