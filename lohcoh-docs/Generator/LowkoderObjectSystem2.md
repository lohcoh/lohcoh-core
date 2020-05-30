# The Lowkoder Object System

The Lowkoder Object System(LOS) is an embedded object system designed to serve as a lightweight and extensible metadata repository.

Background...

In Lowkoder, *metadata* is a tree of data objects that is configured at startup and is thereafter immutable, except by rules.
Like metadata, a context tree is also a tree of data objects.  
A RuleSet is a collection of rules that modify metadata based on the values in a given context tree.

In Lowkoder, every UI component has it's own context and metadata trees. 
Every component's context tree inherits property values from the component's parent's context tree.
Every component's context tree is initialized with property values and then given to the application's RuleSet to create a new metadata tree, customized 
for the associated component by the RuleSet.
The associated component uses the custom metadata to generate content.

LOS is intended to be a metadata repository that can support Lowkoder and implement the functionality required by 
Lowkoder in an a space and time efficient manner, yet still provide a simple, idomatic C# API.

## LOS basics

### LOS objects
A LOS object system is a tree of LOS objects.
To create an instance of a LOS object system you first create a system object and then add more objects to the system's root object...
	
	public class Application : LosObject {
		string Title { get; set; }
	}

    var LOS = new LOSObjectSystem();
	var root= LOS.Select(0); // get the root object
	// Create a new object with the <Application> interface type, assign it to the "Application" property, and then return it
	var app= root.Add<Application>();
	app.Title= "TPS Report Manager 3000";
	var title= root.Get<Application>().Title;  

Things to know...
- Every LOS object is a dictionary of values indexed by the name of the property.
- Every LOS object has an associated C# interface type that subclasses LosObject and that specifies properties.
- A LOS object's type interface may only specify properties.  
	No methods allowed, but properties may return function references.
- LOS properties may only return a LOS object type, a value type, or an immutable object.
	LOS assumes that all the data stored in a LOS object system is only mutable by LOS.	
	Also, LOS properties may not be generic.
- There is no way to create new LOS objects other than the ILosObject.Add method.
- The following line adds a property to the root object, the property type is Application, and, by convention, the property name is "Application"...
		root.Add<Application>(); 
- The following line gets the "Application" property from the root object....
		var app= root.Get<Application>(); 


### Use Extension methods to simplify root access

Instead of this...
	var installedExtensions= root.Get<App>().Extensions.Installed;

You can do this...
	var installedExtensions= root.App.Extensions.Installed;

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
	
		class Hello : LosObject {
			string One {get; set; }
			string Two {get; set; }
			string Three {get; set; }
		}

		class GoodBye : LosObject {
			string One {get; set; }
			string Two {get; set; }
			string Three {get; set; }
		}

	    var LOS = new LOSObjectSystem();
		var root= LOS.Select(0); // get the root object of th master branch

		var hello= new Hello() {
			One= "Howdy",
			Two = "Hi",
			Three = "Hello"
		}; 
		root.Insert(hello); 

		var goodBye= new GoodBye() {
			One= "Bye",
			Two = "Goodby",
			Three = "Later"
		}; 
		root.Insert(goodBye); 

		// creates a branch of the root and changes some properties
		var branch= LOS.Branch(root);
		var hello2= branch.Get<Hello>();
		hello2.One= "Yo";
		hello2.Two = null;

		// all these assertions are true
		Assert.AreEqual("Yo", hello2.One)
		Assert.IsNull(hello2.Two)

		// note that the Hello3 property was never set in the branch, therefore 
		// the current value in the root cascades to the child
		Assert.AreEqual("Hello", hello2.Three)

		// Note that changing properties in the branch did not change the root.
		Assert.AreEqual("Howdy", hello.One)
		Assert.AreEqual("Hi", hello.Two)
		Assert.AreEqual("Hello", hello.Three)

Things to know...
- LOS can support large numbers of branches in a space efficient way because branches don't copy data from thier ancestor.
- LOS efficiently supports deep hierarchies of branches, values are looked up, using an index that includes branch, object, and property Ids.



#### sealing an object.
A LOS object may be sealed to prevent further changes.
Sealing an object has it's advantages because it's often the case that application architecture can be simplified 
and optimized when you know that objects are immutable, so it would be nice if LOS objects were immutable.
OTOH, there are many situations where immuatable objects are more tedious to work with than mutable objects.
The ability to seal objects is a compromise.
Example... 

```
    var LOS = new LOSObjectSystem();
	var root= LOS.Select(0); // get the root object
	var app= root.Add<Application>(); 
	var contect= root.Add<Context>();

	app.Title= "TPS Report Manager 3000"
	var branch= root.Save();
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
root.Subscribe<Application>(app => app.Application.User.Property(u => u.CompanyId))
	.Then(app => DisplayCompanyDashboard(app.User.CompanyId););

Above is same as this...
root.Subscribe(root => root.Application.User.Property(u => CompanyId))
	.Then(root => DisplayCompanyDashboard(root.Application.User.CompanyId););

Which is same as this...
root.Subscribe(root => root.Get<Application>.User.Property(u => CompanyId))
	.Then(root => DisplayCompanyDashboard(root.Get<Application>.User.CompanyId););

// Every time the User object is changed an event is fired if CompanyId is set to "Initech"
root.Subscribe<Application>(app => app.User.Where(u => u.CompanyId == "Initech")
	.Then(e => AddTPSReports());

// Every time the CompanyId is changed an event is fired when the is == "Initech"
root.Subscribe(root => root.Get<Application>.User.Property(u => CompanyId).Where(id => id == "Initech")
	.Then(root => DisplayCompanyDashboard(root.Get<Application>.User.CompanyId););

// Fire event when Company is Initech and the TPS Reports extension is installed.
root.Subscribe(r => r.Application.User.Property(u => CompanyId).Where(id => id == "Initech"))
	&& root.Subscribe(r => r.Application.Extensions.Installed.Where(i => i.Contains("TPS Reports"))))
.Then(e => AddTPSReports());

root.Subscribe(r => r.Application.User.CompanyId == "Initech" && r.Application.Extensions.Installed.Contains("TPS Reports"))
.Then(e => AddTPSReports());
	
Things to know...
- Listeners may only be added to the root branch of an object system, you can't subscribe to branches.
- There is no support for removing listeners.
- Subscriptions always deliver events *after* the change has occurred.

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
