# Software Architecture Patterns That Enhance Extensibility

## Approaches to extensibility that were researched during LowKode development

### Pipelines for component transformation
This idea comes from the Apache Cocoon project.  
Cocoon includes an extensible pipeline for generating and transforming XML documents.
The idea was to do the same for Blazor RenderTrees.
A component would generate it's base RenderTree and then the RenderTree would flow through a pipeline of transformers that would do things 
like inject components for properties, do layout, hook up events to services and such.
This woud require the Blazor-equivalent of XSLT tranformers.
I always kinda hated XSLT, I played with this idea for a while and didn't like it any better, but I think it's feasible.



## Proxies for Application Services
- The proxy API supports pipelines.
- Pipelines are the new AOP.  
	- Pipelines can be used to customize and extend existing services without modifying the original services.
	- Pipelines can be used to implement cross-cutting features, customizations, and extensions.


