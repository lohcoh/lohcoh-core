# lohcoh-graphql

Idiomatic GraphQL for .NET Core.
lohcoh-graphql provides an intuitive, type-safe, object-oriented, GraphQL API for ASP.NET Core developers.

A developer just defines schema types and mutation types in C# and includes them in a schema.
These types are shared with both client and server applications.  

For clients, lohcoh-graphql provides a GraphQL API for sending/receiving requests/responses in a typesafe way, 
and a linq-like query specification API for specifying GraphQL queries.  

For servers, lohcoh-graphql provides a thin API over DotNetCore.GraphQL for processing queries 
and MediatR for handling mutations.

## Basic Usage

### Define schema types and mutations.

Start by creating your data model using Data Annotations...

	using System.ComponentModel.DataAnnotations;

	public class Student
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }        
	}

    public class MySchema : GraphQLSchema
    {
        public MySchema(GraphQLSchemaOptions<MySchema> options) : base(options) { }

        public GraphQLSchemaRoot<Student> Students { get; set; }
	}

### Configure Startup

	public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLohcohGraphQLSchema<MySchema>(options =>
            {
                options.Root= "catalog";
            });
        }
    }

