# lowco development roadmap

## Basic Roadmap
- [Create GraphQL API for eShopOnWeb](#low-ql)

- [Create Blazor UI](#low-UI)
	- lowUI must be capable of reproducing the layout and functionality of the eShopOnWeb user interface.  
		Need not be pixel perfect, just look good.   
	- lowUI uses introspection and metadata roots to build UI
	- Developers will need a typesafe GraphQL API for creating custom templates with GraphQL.  
		So, lowQL will be needed.  
	- lowUI should have typesafe API for intropection and metadata, for implementing generic components.
		if lowQL is build then lowUI can use it.  So lowQL will be built first.

- [Refactor eShopOnWeb](#lowco)
	- everything but artifacts that describe the domain and and schema needs to be moved to lowco module.

### [low QL](lowql.md)
Idiomatic GraphQL for .NET Core.
lowql provides an intuitive, type-safe, object-oriented, GraphQL API for ASP.NET Core developers.
A developer just defines schema types and mutation types in C# and includes them in a schema.  
These types are shared with both client and server applications.
For clients, lowql provides a GraphQL API for sending/receiving requests/responses in a typesafe way and 
a linq-like query specification API for specifying GraphQL queries.
For servers, lowQL provides a thin API over DotNetCore.GraphQL for processing queries and MediatR for handling mutations.

#### roadmap
- After adding GraphQL API is should be possible to write integration tests before proceeding
- GraphQL implementation is contained in an abp module. lowQL.
- A schema is the GraphQL equivalent of DbContext, define public properties for the GraphQL roots.


#### Requirements


### low UI
Idiomatic GraphQL for .NET Core.
lowql provides an intuitive, type-safe, object-oriented, GraphQL API for ASP.NET Core developers.
A developer just defines schema types and mutation types in C#.
lowql provides a linq-like API for specifiying GraphQL queries and a thin API over MediatR for handling mutations.
- 