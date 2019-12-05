# FAQ

** How is lohcode different from [Naked Objects](https://en.wikipedia.org/wiki/Naked_objects)?

	The naked objects pattern is defined by three principles:

	 - All business logic should be encapsulated onto the domain objects. 
		This principle is not unique to naked objects.

	 - The user interface should be a direct representation of the domain objects, with all user actions consisting of creating, retrieving, or invoking methods on domain objects. 
		This principle is not unique to naked objects.

	The naked object pattern's innovative feature arises by combining the 1st and 2nd principles into a 3rd principle:
	- The user interface shall be entirely automatically created from the definitions of the domain objects. 
		This may be done using several different technologies, including source code generation. 
		To date, implementations of the naked objects pattern have favored the technology of reflection.

lohcode embraces all three of these principles.  
However, lohcode's user interface is not monolithic, it's component-based, and the 
domain-driven components supplied by lohcode can be replaced with custom implementations.
Conversely, lohcode's domain-driven components can be reused in a completly custom UI.

