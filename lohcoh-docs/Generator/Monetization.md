# Monetization

## library plugins

Lowkoder works with any component library. 
Components are 'plugged into' Lowkoder via a 'UI Kit'.
Lowkoder will *NOT* provide support for commercial component libraies out of the box but will instead sell UI kits for them.

	Free UI kits...
		Blazorized
		Radzen
		Lowkoder Open Source
	Commercial UI kits...
		SyncFusion
		Telerik
		DevExpress
		PatternFly

## cross-platform components
Makes the core components work across multiple platform; web, phone, desktop

## Apollo-like state management engine for .NET.
Focused on idiomatic C#.
Doesn't use GraphQL, uses LINQ, the .NET type system, MediatR-based mutations.
Integrated with lowkoder, automagically binds queries and mutations to ASP.NET backend services.


# tutorial videos

Some open source projects make money by providing video tutorials on a subscription basis...
https://calebporzio.com/i-just-hit-dollar-100000yr-on-github-sponsors-heres-how-i-did-it

## extended components
Data Tables (should be in the free project?)
Layouts (should definitely be in the free project, is needed for forms)

Search Filters UI + Query API +++++
	The idea here is to provide a metadata-driven GraphQL-like query facility along with search filter UI that enables users to 
	filter search results or even create ad-hoc reports.

Tailwind-like Marketing and ECommerce components; 
Cards
Lists

## built with lowkode
- complete admin UI, generated from a variety of metadata sources.

- User Admin extension for LowKode apps.

- Autocomplete extension
	Remembers the values entered into fields by users and uses those past values to provide autocomplete.

### Tag UI extension +++++
	I think it would be possible to create an extension that would automaginally add tags to 
	Lowkoder forms, without extending the underlying Entities or forms.
	And, if they have the LowKode Search extension, automagically use tags to find data.

- Preferences UI extension
	A UI for configuring user preferences.
	Enables developers to declare Configuration entities, lowKode generates the UI. 
	Configuration is UI only, not for business rules.  
	Configuration is available via Context, can be used with Rules to customize LowKode UI.

## UI generators
- A web application that can generate a complete application, ala Radzen, or HoneyCode. 

- An in-IDE component generator, ala Windows Template Studio.
https://github.com/Microsoft/WindowsTemplateStudio


## for developers
- Visual Studio extension that provides a generated UI for 
	- project configuration artifacts.
	- Entity relationships

#### application blueprints
- Order management. https://www.zoho.com/us/inventory/order-management-software/
- Invoicing
- CMS extension for Lowco.  Grav-like
- CRM.  Like Composity or zoho
- Must at some point have workflow 


