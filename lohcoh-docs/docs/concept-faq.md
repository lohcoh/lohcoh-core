# Questions I ask myself repeatedly about how to build Lowkoder

## Rewrite Lowkoder Context API so that it uses POCO objects
I just know that folks will never b able to wrap thier p brains around the LOS API.

## Should context data be stored as cascading parameters?
Context data is application data, and it doesn't belong in LOS.
But context data needs to be in LOS so that it's available to rules.

## Is it possible to store data in LOS AND as CascadingParameters?
That seems doable


### Implementation
Context data may only be cascaded by type, names will be a future enhancement (it should be possible to implement 
lowkoder using only types, names will probably make things simpler then, but not simpler at the moment).

In order to make context data injectable as [CascadingParameter]s, Scopes will register those 'root' objects 
	
