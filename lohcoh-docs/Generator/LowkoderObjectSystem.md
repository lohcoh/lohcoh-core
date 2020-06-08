# The Lowkoder Object System

The Lowkoder Object System(LOS) is an embedded object system designed to serve as a lightweight and extensible metadata repository.

Background...

In Lowkoder, *metadata* is a tree of data objects that contain, among other things, schema and how to display them.
Metadata is configured at startup and is thereafter immutable.
Like metadata, a context tree is also a tree of data objects, populated at runtime, and contains state information about the current application.
A RuleSet is a collection of rules that modify a given metadata tree based on the values in a given context tree.

In Lowkoder, every UI component has it's own context and metadata trees. 
Every component's context tree inherits property values from the component's parent's context tree.
Every component's context tree is initialized with property values and then given to the application's RuleSet to create a new metadata tree, customized 
for the associated component by the RuleSet.
The UI component uses the custom metadata to generate content.

A naive implementation of such a content repository would create a custom copy of the entire object tree for each Lowkoder component.
LOS is intended to be a metadata and context repository that can support the Lowkoder framework in a space and time efficient manner, 
yet still provide a simple idomatic C# API.

## Object System
A LOS object system is a tree of data objects.
Think of a LOS object system as a kind of micro database that stores many versions of a single object tree.
Each version of the object tree is called a branch.
Operations are performed on the root of a branch.
A specific branch of the tree root may be selected from the object system, then mutated, then saved to the object system 
to create a new branch of the tree.

	using (var root = los.Open(revision)
	{
		// get columns for edit table for a given model type
		var columns = root.ColumnsSets.Where(columns => set.SystemType == modelType).Items;
	}

Immediately after an object system is created it has a single branch, called the prime branch, which is initially empty.
Immediately after an object system is created the prime branch should be populated and saved to create a *master* branch.
Any branch created from the prime brnach is referred to as a master branch.

## Creating and initializing an object system

A tree 'root' is the LOS equivalent of an Entity Framework context, it represents a session and it defines the data contained 
in a LOS object tree.
To create an instance of a LOS object system you first create a system object, then 'prime' the system by creating the master branch...

	public class Application {
		public virtual string Title { get; set; }
	}

	public abstract class BloggingApplicationRoot : LosRoot
    {
		public virtual Application Application { get; set; }
        public virtual List<BlogSubscription> Blogs { get; set; }
        public virtual PostsDashboard Posts { get; set; }        
        public virtual List<Reports> Reports { get; set; }        
    }

	var bloggingRoot= new BloggingApplicationRoot() {
		Application= new Application() { Title= "TPS Report Manager 3000" },
		Blogs= blogConfig.GetBlogSubscriptions(),
		// etc...
	}

    var los = new LOSObjectSystem();
	var prime= los.Open();
	prime.Put(lowkoder.GetLowkoderRoot());
	prime.Put(bloggingRoot);
	var master= prime.Save();

	Assert.AreEqual(application.Title, master.Get<Application>().Title);


Things to know...
- Every LOS object is a dictionary of values indexed by the name of the property.
- Every LOS object has an associated C# type that specifies properties.
- There are a lot of restrictions on the definition of LOS object types.
	A LOS object type may only specify properties, no methods allowed, but properties may return function references.
	Properties may only return a LOS object type, a value type, or an immutable object.
	Also, properties may not be generic.
- All data stored in a LOS object system is immutable.  
	The only way to add/change data is to Select a root, mutate the object tree, and save the tree to a new branch.
- By convention, the 0th branch of a LOS object system is called the *prime* version.
	The prime version is initially empty and immutable, it's only purpose is to initialize the object system 
	with an object tree.  
- By convention, a branch created from the prime branch is called a *master* branch.

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

		var master= LOS.Prime
			.Put<Hello>(h => {
				h.One= "Howdy";
				h.Two = "Hi";
				h.Three = "Hello";
			})
			.Put<GoodBye>(g => {
				g.One= "Bye";
				g.Two = "Goodby";
				g.Three = "Later";
			})
			.Save();

		// creates a branch of the root and changes some properties
		master.Get<Hello>(h => {
			h.One= "Yo";
			h.Two = null;
		});

		// Note that at this point the following line evaluates to true.
		// This is because the ILosRoot.Get method returns a copy of the denoted tree.
		Assert.AreEqual("Howdy", LOS.Select(master.Revision).Get<Hello>().One);

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
	
Rules are used by a LOS object system to configure branches.
Rules may be added to the prime branch, and only the prime branch.
When an object tree is saved the rules are applied to the new branch produced by the saved object tree.

Example...

Suppose an object system is primed with this data, that defines menu items displayed by the application.
prime.Put<Application>(a => {
	a.Navigation.Items.Add(new Item() { Label= "Orders"});
		.Put(i => i.Label= "Orders")
		.Put(i => i.Label= "Customers");
});


Now suppose that we want to display an additional menu item labeled "TPS Reports" when the user works for Initech....
prime.When<Application>(a => a.User.CompanyId == "Initech")
	.Then(e => a.Navigation.Items.Put(i => i.Label = "TPS Reports"));

This rule adds a new item to list of menu items to be displayed by the application.
You might be wondering what happens if the above rule is executed and then the User changes, to someone that doesn't work for Initech.
Blazor doesn't work by changing things, Blazor rerenders things.
So, it's expected when a scope changes that all components rendered within that scope will be rerendered, which also causes all new child 
scopes to be created.
So, the short answer to the question about what happens when context changes is that scopes are rerendered.



// Whenever the CompanyId is changed then add company specific items to the main navigation menu...
prime.When<Application>(app => app.User.CompanyId)
	.Then(app => app.Navigation.ConfigureCompanyItems(app.User.CompanyId));

prime.Rule<Application>(app => )

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
