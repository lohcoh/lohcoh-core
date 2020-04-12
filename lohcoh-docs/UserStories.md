# User Stories
This document contains a running list of user stories.
This list of stories guides lowcode's design and implementation.


## Reduce Technical Debt
As a developer, I prefer to get salary increases and promotions instead of getting fired.
So, when I am charged with developing a new line of business application I would appreciate a tool that makes it easier 
to create a high quality UI with less work, without sacrificing flexibility in the design or implementation of the UI.

# 

lowkode consists of the following high level components...

- metadata service: an extensible backend metadata service that scans your application's 
artifacts and assemblies at startup, collects metadata, and stores that information in memory.

- query API: An API for querying the metadata service for metadata.
Both clients and backend libraries should be able to query metadata using the same API.

- metadata provider API: An API, to be used by server-side services, for writing metadata to the metadata service.

- query service: A controller service that makes the metadata stored in the metadata service available to web clients






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

