

var	MainMenuItems= ctx.Root.Application.Navigation.Items.Where(i => i.Visible))



# The Lowkoder Object System

The Lowkoder Object System(LOS) is an embedded object system designed to serve as a lightweight and extensible metadata repository.

Background...

In Lowkoder, *metadata* is a tree of data objects that contain, among other things, types and information about how to display them.
Metadata is configured at startup and is thereafter immutable.
Like metadata, a context tree is also a tree of data objects, populated at runtime, and contains state information about the current application.
A RuleSet is a collection of rules that modify a given metadata tree based on the values in a given context tree.

In Lowkoder, every UI component has it's own context and metadata trees. 
Every component's context tree inherits property values from the component's parent's context tree.
Every component's context tree is initialized with property values and then given to the 
application's RuleSet to create a new metadata tree, customized for the associated component by the RuleSet.
The UI component uses the custom metadata to generate content.

LOS is intended to be a metadata and context repository that can support the Lowkoder framework in a space and time efficient manner, 
yet still provide a simple idomatic C# API.

## Object System
A LOS object system is a tree of data objects.
Think of a LOS object system as a kind of micro database that stores many versions of a single object tree.
Each version of the object tree is called a branch.
Operations are performed on the root of a branch.
A specific branch of the tree root may be selected from the object system, then mutated, then saved to the object system 
to create a new branch of the tree.

Immediately after an object system is created it has a single branch, called the prime branch.
The prime branch has an index of -1;
Immediately after an object system is created the prime branch should be populate and saved to create the *master* branch.
The master branch has an index of 0.

## Creating and initializing an object system

To create an instance of a LOS object system you first create a system object, then 'prime' the system by creating the master branch...
	
	public class Application {
		string Title { get; set; }
	}
	var application = new Application() {
		Title= "TPS Report Manager 3000"
	};

    var LOS = new LOSObjectSystem();
	var 

	LOS.AddRoot(application);
	LOS.AddRoot(new LowkoderRoot());

	var master= Los.Open();

	// evaluates to true
	Assert.AreEqual(application.Title, master.Get<Application>().Title);

	// Note that inserting data into a LOS object system is like inserting data into a database
	// So, you cannot do this...
	application.Title= "ACME";
	// throws an error...
	Assert.AreEqual(application.Title, master.Get<Application>().Title);


Things to know...
- Every LOS object is a dictionary of values indexed by the name of the property.
- Every LOS object has an associated C# type that specifies properties.
- There are a lot of restrictions on the definition of LOS object types.
	A LOS object type may only specify properties, no methods allowed, but properties may return function references.
	Properties may only return a LOS object type, a value type, or an immutable object.
	Also, properties may not be generic.
- All data stored in a LOS object system is immutable.  
	The only way to add data is to Select a root, mutate the object tree, and save the tree to a new branch.
- By convention, the 0th branch of a LOS object system is called the *prime* version.
	The prime version is initially empty an immutable, it's only purpose is to initialize the object system 
	with an object tree.

## Use Extension methods to simplify root access

Instead of this...
	var installedExtensions= root.Get<Application>().Extensions.Installed;

You can do this...
	var installedExtensions= root.Application.Extensions.Installed;

If you create an extension method...
	namespace LowKode.Core.Metadata {
		public static class MyMetadataRoots {
			public static Application Application(this ILosRoot root) => root.Get<App>();
		}
	}

Note: By convention, in Lowkoder metadata root extensions are declared in the Lowkoder.Core.Metadata namespace 
and context root extensions are declared in the Lowkoder.Core.Context namespace, thus making it easier 
to discover all root extensions contributed by assemblies.

This documentation often assumes that this convention is being employed.

## LOS objects and LOS roots

## LOS Branching

This example illustrates how branches inherits data from it's parent, unless explicitly overwritten in the child...
	
		class Hello {
			string One {get; set; }
			string Two {get; set; }
			string Three {get; set; }
		}

		class GoodBye {
			string One {get; set; }
			string Two {get; set; }
			string Three {get; set; }
		}

	    var LOS = new LOSObjectSystem();
		var master= LOS.Select(0); 

		var hello= new Hello() {
			One= "Howdy",
			Two = "Hi",
			Three = "Hello"
		}; 
		master.Insert(hello); 

		var goodBye= new GoodBye() {
			One= "Bye",
			Two = "Goodby",
			Three = "Later"
		}; 
		master.Insert(goodBye); 
		var root= master.Save();

		// creates a branch of the root and changes some properties
		var hello2= root.Get<Hello>();
		hello2.One= "Yo";
		hello2.Two = null;

		// Note that at this point the following line evaluates to true.
		// This is because the ILosRoot.Select method returns a copy of the denoted tree
		Assert.AreEqual("Howdy", LOS.Select(root.Revision).Get<Hello>().One);

		var branch= root.Save();

		// all these assertions are true
		Assert.AreEqual("Yo", branch.Get<Hello>.One)
		Assert.IsNull(branch.Get<Hello>.Two)

		// note that the Hello3 property was never set in the branch, therefore 
		// the current value in the root cascades to the child
		Assert.AreEqual("Hello", branch.Get<Hello>.Three)

		// Note that changing properties in the branch did not change the root.
		Assert.AreEqual("Howdy", root.Get<Hello>.One)
		Assert.AreEqual("Hi", root.Get<Hello>.Two)
		Assert.AreEqual("Hello", root.Get<Hello>.Three)

Things to know...
- LOS can support large numbers of branches in a space efficient way because branches don't copy data from thier ancestor.
- LOS efficiently supports deep hierarchies of branches.


### LOS Rules
	
Rules are used by a LOS object system to configure metadata.
Rules are added to the prime branch.  
When an object tree is saved the rules are executed against the tree being saved and any changes made by the rules 
are applied to the newly created branch.

// When the CompanyId changes then add company specific items to the main navigation menu...
prime.When<Application>(app => app.User.CompanyId)
	.Then(app => app.Navigation.AddCompanyItems(app.User.CompanyId));

// When CompanyId is "Initech" then add the TPS reports extension
prime.When<Application>(app => app.User.CompanyId == "Initech")
	.Then(e => app.Extensions.AddTPSReports());

// When Company is Initech and the TPS Reports extension is installed then add navigation items
prime.When<Application>(app => app.User.CompanyId == "Initech" && app.Extensions.Installed.Contains("TPS Reports"))
.Then(e => app.Navigation.AddTPSReports());

Things to know...
- Listeners may only be added to the initialization branch of an object system, you can't subscribe to branches.
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
