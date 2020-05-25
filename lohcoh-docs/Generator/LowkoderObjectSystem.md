# The Lowkoder Object System

The Lowkoder Object System(LOS) is an embedded object system designed to serve as a lightweight and extensible metadata repository.

Background...

In Lowkoder, *metadata* is a tree of data objects that is configured at startup and is thereafter immutable.
Like metadata, a context tree is also a tree of data objects.  
A RuleSet is a collection of rules where the rules in the collection modify property values in a given 
metadata tree based on the property values in a given context tree.

In Lowkoder, every UI component has it's own context tree. 
Every component's context tree inherits property values from the context tree associated with the component's parent.
Every component's context tree is initialized with property values and then given to the application's RuleSet to create a new metadata tree, customized 
for the associated component by the RuleSet.
The associated component uses the custom metadata to generate content.

LOS is intended to be a metadata repository that can support Lowkoder and implement the functionality required by 
Lowkoder in an a space and time efficient manner, yet still provide a simple, idomatic C# API.

## LOS basics

### LOS objects
A LOS object system is a tree of LOS objects.
To create an instance of a LOS object system you first create a system object and then add more objects to the system's root object...

	interface Application {
		string Title { get; set; }
	}

    var LOS = new LOSObjectSystem();
	var root= LOS.Root; // get the root object
	// Create a new object with the <Application> interface type, assign it to the "Application" property, and the return it
	var app= root.Add<Application>(app => { 
		app.Title= "TPS Report Manager 3000"; 
	})
	var title= root.Get<Application>().Title;  // get the application title

Things to know...
- Every LOS object is a dictionary of other LOS objects, indexed by the type of the property.
- Every LOS object has an associated C# interface type that subclasses ILosObject and that specifies properties.
- A LOS object's type interface may only specify properties.  No methods allowed, but properties may return function references.
- LOS properties may only return a LOS object type, a value type, or an immutable object.
	LOS does not attempt to track changes to non-LOS objects, and mutating non-LOS objects stored on LOS can have negative side-effects.
- LOS properties may not be generic.
- There is no way to create new LOS objects other than the ILosObject.Add method.
- The following line adds a property to the root object, the property type is Application, and, by convention, the property name is "Application"...
		root.Add<Application>(); 
- The following line gets the "Application" property from the root object....
		var app= root.Get<Application>(); 


### Use Extension methods to simplify root access

Instead of this...
	var installedExtensions= root.Get<App>().Extensions.Installed

You can do this...
	var installedExtensions= root.App.Extensions.Installed

If you create an extension method...
	namespace LowKode.Core.Metadata {
		public static class MyMetadataRoots {
			public static Application App(this IMetadataRoot meta) => meta.Get<App>();
		}
	}

Note: By convention, in Lowkoder metadata root extensions are declared in the Lowkoder.Core.Metadata namespace 
and context root extensions are declared in the Lowkoder.Core.Context namespace, thus making it easier 
to discover all root extensions contributed by assemblies.

This documentation often assumes that this convention is being employed.

### LOS Branching

It's possible to create new versions of an existing object tree, the newly created object tree will inherit values 
from it's parent, unless explicitly overwritten in the child...
	
		interface Hello {
			string One {get; set; }
			string Two {get; set; }
			string Three {get; set; }
		}

		interface GoodBye {
			string One {get; set; }
			string Two {get; set; }
			string Three {get; set; }
		}

	    var LOS = new LOSObjectSystem();
		var root= LOS.Root; // get the root object

		root.Add<Hello>(hello => {
			hello.One= "Howdy",
			hello.Two = "Hi",
			hello.Three = "Hello"
		}); 
		root.Add<GoodBye>(bye => {
			bye.One= "Bye",
			bye.Two = "Goodby",
			bye.Three = "Later"
		}); 

		// creates a branch of the root and changes some properties
		var branch= root.Branch(branch => {
			branch.One= "Yo",
			branch.Two = null
		}); 

		// all these assertions are true
		Assert.AreEqual("Yo", branch.One)
		Assert.IsNull(branch.Two)

		// note that the Hello3 property was never set in the branch, therefore 
		// the current value in the root cascades to the child
		Assert.AreEqual("Hello", branch.Three)

		// Note that changing properties in the branch did not change the root.
		Assert.AreEqual("Howdy", root.One)
		Assert.AreEqual("Hi", root.Two)
		Assert.AreEqual("Hello", root.Three)

Things to know...
- LOS can support large numbers of branches in a space efficient because branches don't copy data from thier ancestor.
- LOS efficiently supports deep hierarchies of branches by not passing requests for property values up the tree of 
branches to the branch that holds the value.  Instead, values are looked up, using an index that includes branch, object, and property Ids.



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
	var app= root.Add<Application>(); 
	var contect= root.Add<Context>();

	app.Title= "TPS Report Manager 3000"
	root.Sealed= true;
	app.Title= "Acme Report Manager"; // throws error: "object is sealed"
	app.Add<MyExtentionMetadata>(); // throws error: "object is sealed"
```

Things to know...
- branches (discussed later) *do not* inherit locks.  Branches are open to changes when they are first created.
- Unsealing an object is not supported 
- Lowkode always seals an object after populating it with properties and events.


### LOS Event Subscriptions
	
It's easy to listen to changes to an object system...

// Event fired whenever the CompanyId property is changed...
root.Application.User.Subscribe(u => u.CompanyId).Then(e => DisplayCompanyDashboard(e.User.CompanyId););

// Event is fired only when CompanyId is set to "Initech"
root.Application.User.Subscribe(u => u.CompanyId == "Initech").Then(e => AddTPSReports());

// Fire event when Company is Initech and the TPS Reports extension is installed.
(		root.Application.User.Subscribe(u => u.CompanyId == "Initech")
	&&	root.Application.Extensions.Installed.Subscribe(x => x.Contains("TPS Reports"))
)
.Then(e => AddTPSReports());

// Event fired whenever the User object is changed...
root.Application.User.Subscribe().Then(e => "do something here");
	
Things to know...
- Listeners may only be added to the root branch of an object system. 
	Put another way, you can't subscribe to LOS objects in branches.
- There is no support for removing listeners.
- Event handlers may only subscribe ILOSObjects.
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
