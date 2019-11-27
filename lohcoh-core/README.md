# lohcoh-core

lohcoh-core is a simple module and metatdata facility.

### Why lohcoh needs a module and metadata system

lohcoh is meant to be a development platform that reduces the effort required to create software of all kinds, 
but mostly line of business applications.  
Since changing a system is most often significantly easier than creating a system, lohcoh reduces the effort 
needed to build applications by essentially being a complete application in a box that can be extended 
and customized.  

Therefore, lohcoh is designed to support change.  
Lohcoh depends heavily on two patterns that help when designing for change:

#### Microkernel Pattern 
The Microkernel pattern applies to software systems that must be able to adapt to changing system requirements. 
It separates a minimal functional core from extended functionality and customer-specific parts. 
The microkernel also serves as a socket for plugging in such extensions and coordinating their
collaboration.  lohcoh doesn't have a full-blown microkernel, lohcoh is not interested in dynamically 
adding functionality, like an IDE.  
lohcoh has a mininimal Module API that is needed for the system to discover its parts.

#### Reflection Pattern

The Reflection pattern provides a mechanism for changing structure and behavior of software systems dynamically. 
In this pattern, an application is split into two parts. 
A meta level provides information about selected system properties and makes the software self-aware. 
A base level includes the application logic. 
Its implementation builds on the meta level. 
Changes to information kept in the meta level affect subsequent base-level behavior.  

This is the main purpose of the lohcoh-core module, it discovers all the metadata embedded in the system 
and provides a facility for other modules to query that data.  

Libraries should not have to know the details of where metadata is saved and how to fetch it, so lohcoh-core does all that.
lohcoh gathers information from many places and makes it available in a common format...
- .NET has a reflection system that provides information about assemblies and the types defined within them.
- .NET also provides an API for configuration information.
- .NET also provides Attributes used to add metadata to types

lohcoh-core gathers metadata from many sources and makes it available to other modules 
using a very simple query facility similar to GraphQL.  


#### Adding new sources of metadata

Modules can extend lohcoh-core with thier own sources of metadata.

As an example...   

Suppose we want create a module that will add a main navigation menu to an application.
How will the developer tell the system what menu items should be included?  

There are many possibilities...
- configuration file
- a convention, like defining classes in a folder that denote menu items.
- Adding Attributes to classes.

The lohcoh way of implementing this menu is to have the module that implements the menu define a 
type that represents a menu item, let's call this type 'MainNavigationMenuItem'.  
Other modules can define menu items in what ever way they want, in a configuration file, using annotations, whatever.  
Modules that provide menu items might need to add a dependency on a module that provides a metadata provider to lohcoh-core so 
that lohcoh-core can discover the menu items, if lohcoh-core doesn't already have a suitable provider.
At startup, lohcoh-core discovers the menu items and adds 'MainNavigationMenuItem' metadata objects that 
represent the menu items to the system's metadata.  
Then, at runtime, the module that implements the menu will query lohcoh-core to get a list of all the menu items 
that should be included on the menu.

