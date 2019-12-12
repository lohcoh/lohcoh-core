# ToDo

## lowkode next steps

- create Lowkode API repository and load swagger.json at startup.
	- Lowkode API repository uses [OpenAPI.NET](https://github.com/microsoft/OpenAPI.NET)
	- The repository provides an API for executing Linq queries aginst the OpenAPI.NET 
	document.  In the future the repository will be extended to allow query transformations 
	to be plugged into the query processing.

	idea:  

- rewrite DisplayTable to use OpenAPI and eliminate all hard-coded text and data

- rewrite FetchData.razor to eliminate hard-coded data fetching

	- lowkode will need a data source api that can hook up an OpenAPI endpoint to a 
	component's input parameter.

		- This API should be generic and reactive, so that the endpoint can be connected to 
		a service that posts updates.
