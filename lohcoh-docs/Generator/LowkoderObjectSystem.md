# The Lowkoder Object System

The Lowkoder Object System(LOS) is an embedded object system designed to serve as a lightweight and extensible metadata repository.

Background...
In Lowkoder, *metadata* is a tree of data objects that is configured at startup and is thereafter immutable.
Like metadata, a context tree is a tree of data objects.  
A RuleSet is a collection of rules where the rules in the collection modify property values in a given 
metadata tree based on the property values in a given context tree.

In Lowkoder, every UI component Lowkoder has it's own context tree. 
Every component's context tree is initialized with property values, the context tree also inherit property values 
from the context associated with the component's parent.
After a component's context tree is configured it is given to the application's RuleSet to create a new metadata tree, customized 
for the given conext by the RuleSet.
The associated component uses the custom metadata to generate content.

LOS is intended to be a metadata engine that can support Lowkoder and implement the functionality required by 
Lowkoder in an a space and time efficient manner, yet still provide a simple, idomatic C# API.


## LOS basics

### LOS objects
A LOS object system is a tree of LOS objects.
To create an instance of a LOS object system you first create a system object and then add more objects to the system's root object...

    var LOS = new LOSObjectSystem();
	var root= LOS.Root; // get the root object
	// Create a new object with the <Application> interface type, assign it to the "Application" property, and the return it
	var app= root.New<Application>(); 
	app.Title= "TPS Report Manager 3000"
	var title= root.Get<Application>().Title;  // get the application title

Things to know...
- Every LOS object has a dictionary of properties, indexed by the name of the property.
- Every LOS object has an associated C# interface type that specifies properties.
- A LOS object's type interface may only specify properties.
- LOS properties may only return a LOS object, a value type, or an immutable object.
	LOS does not attempt to track changes to non-LOS objects, and mutating non-LOS objects stored on LOS can have negative side-effects.
- There is no way to create new LOS objects other than the ILosObject.New method.
- This line...
		root.New<Application>(); 
	...Adds a property to the root object, the property type is Application, and, by convention, the property name is "Application".
- This line...
		var app= root.Get<Application>(); 
	...gets the property named "Application" from the root object.  
	If the property value is not null and not an instance of Application then null will be returned.
- This line...
		var app= root.Get<Application>("Foobar"); 
	...gets the property named "Foobar" from the root object.  
	If the property value is not null and not an instance of Application then null will be returned.
	You can also do this... 
		var app= root.Get("Foobar"); 

#### sealing an object.
A LOS object may be sealed to prevent further changes.
Sealing an object has it's advantages because it's often the case that application architecture can be simplified 
and optimized when you know that objects are immutable, so it would be nice if LOS objects were immutable.
OTOH, there are many situations where immuatable objects are more tedious to work with than mutable objects.
The ability to seal objects is a compromise.
Example... 

```
    var LOS = new LOSObjectSystem();
	var root= LOS.Root; // get the root object
	var app= root.New<Application>(); 
	var contect= root.New<Context>();

	app.Title= "TPS Report Manager 3000"
	root.Sealed= true;
	app.Title= "Acme Report Manager"; // throws error: "object is sealed"
	app.New<MyExtentionMetadata>(); // throws error: "object is sealed"
```

Things to know...
- branches (discussed later) *do not* inherit locks.  Branches are open to changes when they are first created.
- Unsealing an object is not supported 
- Lowkode always seals an object after populating it with properties and events.

### Use Extension methods to simplify root access

Instead of this...
	var installedExtensions= root.Get<App>().Extensions.Installed

you can do this...
	var installedExtensions= root.App.Extensions.Installed

if you create an extension method...
	namespace LowKode.Core.Metadata {
		public static class MyMetadataRoots {
			public static Application App(this IMetadataRoot meta) => meta.Get<App>();
		}
	}

Note: By convention, metadata root extensions are declared in the LowKode.Core.Metadata namespace 
and context root extensions are declared in the LowKode.Core.Context namespace, thus making it easier 
to discover all root extensions contributed by assemblies.



### LOS Events
	
It's easy to listen to changes to an object system...

// Event is fired when CompanyId is set to "Initech"
root.Application.User.Subscribe(u => u.CompanyId == "Initech")
.Then(e => "do something here");

// Events are fired when BOTH conditions are satisfied
(root.Application.User.Subscribe(u => u.CompanyId == "Initech")
	&& root.Application.Extensions.Subscribe(x => x.Installed.Contains("TPS Reports")))
.Then(e => "do something here");

// Event fired whenever the CompanyId property is changed...
root.Application.User.Subscribe(u => u.CompanyId).Then(e => "do something here");

// Event fired whever the User object is changed...
root.Application.User.Subscribe().Then(e => "do something here");
	
Things to know...
- Listeners may only be registers on root objects. There is no support for removing listeners.
- Event handlers may only be registed on LOS objects and properties of LOS objects.
- Listener are inherited by branches unless the listener is explicitly removed from the branch.	
- Subscriptions always deliver events *after* the change has occurred.
- Subscriptions deliver an event object to listeners that contains important info, like old values and such.

### Constructing Hierarchies 

By convention, the interface types used by your objects are usually named and arranged in a way that constructs an intuitive hierarchy of values.
For instance, consider these interfaces....

	interface Application {
		IExtensions Extensions { get; } 
	}

	interface Extensions {
		IEnumerable<IExtension> Installed { get; } 
	}

Given the above interface definitons, here's how you might use them to discover all the extensions installed in the current application...

	var installedExtensions= root.App.Extensions.Installed

### Extensions






### LOS Versioning

It's possible to create new versions of an existing object system, the newly created object system will inherit values 
from it's parent, unless explicitly overwritten in the child...

	    var LOS = new LOSObjectSystem();
		var root= LOS.Root; // get the root object

		root.Add<string>("Hello1", "Howdy"); 
		root.Add<string>("Hello2", "Hi"); 
		root.Add<string>("Hello3", "Hello"); 

		// creates a branch of the root and change some properties
		var branch= LOS.Branch(); 
		branch.Set("Hello1", "Yo");
		branch.Remove("Hello2");

		// all these assertions are true
		Assert.AreEqual("Yo", branch.Get("Hello1"))
		Assert.IsNull(branch.Get("Hello2"))

		// note that the Hello3 property was never set in the branch, therefore 
		// the current value in the root cascades to the child
		Assert.AreEqual("Hellow", branch.Get("Hello3"))

		Assert.AreEqual("Howdy", root.Get("Hello1"))

		// Note that removing a property from the child did not remove it from the root.
		Assert.AreEqual("Hi", root.Get("Hello2"))

		Assert.AreEqual("Hello", root.Get("Hello3"))

Things to know...
- LOS can support large numbers of branches because branches don't copy data from thier ancestor, requests for properties 
that have not been explicitly set in a banch are delegated to an ancestor.
- LOS efficiently supports deep hierarchies of branches.  Requests for property values are not passed up the tree of 
branches to the branch that holds the value.  

