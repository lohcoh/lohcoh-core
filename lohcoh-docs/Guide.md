# lowkode metadata management

# Guide
## Essentials
### What is lowkode?
## lowkode UI
### Placeholder Components
### Creator Components

#### Lowkode OpenAPI Queries
	Creator components query the Lowkode OpenAPI repository for metadata.

	API queries include a 'context'.  
	A context is a dictionary that contains metadata objects indexed by type.  
	The context is used to customize query results for the specific context.

### Customization with Query Transformations
	Lowkode UIs are customized by customizing the query results returned by the Lowkode API repository.
	Query results are customized by a pipeline of *transformations*.
	Transformations have two parts, a condition and an action.
	A condition is a LINQ expression that queries the context and returns a value if the action should be fired.
	The action is a LINQ transformation on the query results.

	For instance, if you wanted to hide a field on a form for a specific customer, you 
	would create a transformation with:
	- a condition expression that would select the specific customer for which the customization applies.
		Something like this:  context.Any<IUser>().Where(u => u.Company.Name == "ACME")
	- an action that sets the 'hidden" property on the field...
		results.Any<ICustomer>.Fields().Where(f => f.Name == nameof(ICustomer.ICannNumber))
			.Attributes.Set("hidden", true)

## lowkode Server
### Using NSwag 
### Adding OpenAPI metadata

