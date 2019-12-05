# lohcoh-core

lohcoh-core is a simple module and metatdata facility.

## Why lohcoh needs a module and metadata system

lohcoh is meant to be a development platform that reduces the effort required to create software of all kinds, 
but mostly line of business applications.  
Since changing a system is most often significantly easier than creating a system, lohcoh reduces the effort 
needed to build applications by essentially being a complete application in a box that can be extended 
and customized.  

Therefore, lohcoh is designed to support change.  
Lohcoh depends heavily on two patterns that help when designing for change:

### Microkernel Pattern 
The Microkernel pattern applies to software systems that must be able to adapt to changing system requirements. 
It separates a minimal functional core from extended functionality and customer-specific parts. 
The microkernel also serves as a socket for plugging in such extensions and coordinating their
collaboration.  lohcoh doesn't have a full-blown microkernel, lohcoh is not interested in dynamically 
adding functionality, like an IDE.  
lohcoh has a mininimal Module API that is needed for the system to discover its parts.

### Reflection Pattern

The Reflection pattern provides a mechanism for changing structure and behavior of software systems dynamically. 
In this pattern, an application is split into two parts. 
A meta level provides information about selected system properties and makes the software self-aware. 
A base level includes the application logic. 
Its implementation builds on the meta level. 
Changes to information kept in the meta level affect subsequent base-level behavior.  

This is the main purpose of the lohcoh-core module, it discovers all the metadata embedded in an application 
and provides a facility for other modules to query that data.  

Libraries should not have to know the details of where metadata is saved and how to fetch it, so lohcoh-core does all that.
lohcoh gathers information from many places and makes it available in a common format...
- .NET has a reflection system that provides information about assemblies and the types defined within them.
- .NET also provides an API for configuration information.
- .NET also provides Attributes used to add metadata to types

lohcoh-core gathers metadata from many sources and makes it available to other modules 
using a very simple query facility similar to GraphQL.  

## Exposing metadata

There are endless ways to get metadata into lohcoh's metadata repository because new metadata providers can 
be plugged into lohcoh-core.  
The most common way of exposing the metadata in a system is to add an attribute to c# class.
For instance, in the code below, the [IsAggregate] attribute identifies the OrderItem class 
as a DDD aggregate.  
At startup, lohcoh will discover the IsAggregate annotation and call the handler for the 
IsAggregate attribute.
The attribute handler will put an instance of Lohcoh.Modeling.Aggregate into the lohcoh registry, which 
will be used later by other modules to create database tables for the entities, 
create GraphQL schema, create CRUD mutations, create forms for viewing and editing, etc.

	[IsAggregate]
    public class OrderItem : BaseEntity
    {
        public CatalogItemOrdered ItemOrdered { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Units { get; private set; }

        private OrderItem()
        {
            // required by EF
        }

        public OrderItem(CatalogItemOrdered itemOrdered, decimal unitPrice, int units)
        {
            ItemOrdered = itemOrdered;
            UnitPrice = unitPrice;
            Units = units;
        }
    }


