# The Lowkoder Object System

The Lowkoder Object System(LOS) is an embedded object system designed to serve as a lightweight, extensible, versioned metadata and context repository.

LOS provides space-efficient versioning, the ability to dynamically extend object types, react to changes, implement cross-cutting functionality, etc.
A goal of LOS is to provide these advanced behaviors in a simple idomatic C# fashion.

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
- A LOS object's type interface properties may not be generic.
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

		// then make a change to the root 
		root.Set("Hello3", "Greetings");
		
		// all these assertions are true
		Assert.AreEqual("Yo", branch.Get("Hello1"))
		Assert.IsNull(branch.Get("Hello2"))

		// note that the Hello3 property was never set in the branch, therefore 
		// the current value in the root cascades to the child
		Assert.AreEqual("Greetings", branch.Get("Hello3"))

		Assert.AreEqual("Howdy", root.Get("Hello1"))

		// Note that removing a property from the child did not remove it from the root.
		Assert.AreEqual("Hi", root.Get("Hello2"))

		Assert.AreEqual("Greetings", root.Get("Hello3"))


LOS supports large numbers of versions of large object systems in a space-efficient way.


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
- Event handlers are not registered on properties, they are registered on objects.
- When a listener is attached to an object, that listener is inherited by all branches of 
	that object, unless the listener is explicitly removed from the branch.	
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


