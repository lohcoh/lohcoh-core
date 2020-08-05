# Questions I ask repeatedly myself about how to build Lowkoder

## Rewrite Lowkoder Context API so that it uses POCO objects
I just know that folks will never b able to wrap thier p brains around the LOS API.
I just know that an implementation that uses POCO vs an object system will be easier to learn and therefore possibly more easily adopted.
A need for LOS still exists, as a container of context values.  
LOS makes context data available to drive rules/customization.

## Should context data be stored as cascading parameters?
At 1st blush, Context data is application data and it doesn't belong in LOS.
But context data needs to be in LOS so that it's available to rules.

## Is it possible to store data in LOS AND as CascadingParameters?
At 1st blush that seems doable.  
Just have the <Scope> component stores the data in LOS and creates Cascading Parameters.
But, when using nested Scopes in a template, it will be necessary to be able to consume and provide 
data without using Cascading Parameters.
So let's not have two ways of doing something, stick with just the <Scope> component.


### Implementation
Context data may only be cascaded by type, names will be a future enhancement (it should be possible to implement 
lowkoder using only types, names will probably make things simpler then, but not simpler at the moment).

