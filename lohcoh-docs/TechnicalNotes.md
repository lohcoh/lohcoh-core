# Technical Notes

## One Possible Implementation: UI Model + Context = metadata

Basic Workflow...
- Create UI Model using lohcode Blazor components
- On Startup in Blazor app, 

### Inspired by
	[MetaUI](https://www.metaui.io/) is an OK example of how to design a metadata-driven UI, but it's WAY complicated.
	[This article](https://hacks.mozilla.org/2017/08/inside-a-super-fast-css-engine-quantum-css-aka-stylo/) shows 
	how a rule engine (that applies selectors to a DOM) works.
	
## Customization Stories
- Add an item to a navigation menu for a particular customer
- Highlight a number in a table if it's above a certain number
	- Rule-driven pipe (angular pipe)?
- Change form layout based on customer
- Call different endpoint based on tenant (this is probably better handled by server)
- Enable features if user paid for Enterprise Edition

## Metadata processing
Need to keep lowkode simple and understandable.
It's difficult to understand rule engines, especially forward-chaining engines.
Right now I'm thinking that component implementations query the LowkodeRepository with LINQ.
After an set of results is built the results can be customized with pipeline transformers, ala Apache Cocoon.

### Metadata processing - take 2
JSON Schema provides mechanisms for customizing schemas, perhaps lowkode should use these mechanisms to customize schema.
The downside... binds lowkode to JSON Schema.

## Metadata Providers

### Metadata Initialization
+ Register Metadata providers as scoped services.
+ lohcode creates a new Scope for the purpose of populating metadata repository.
+ 'ConfigureServices' gets called on each provider so provider can register any additional services needed just for metadata discovery.
+ 'ConfigureMetadata' gets called on each provider, provider uses Options API to contribute and configure metadata
+ lohcode engine fetches all Options contributions from Scope
+ lohcode configures NSwag with Options

The design of Configuration types should mirror the OpenApi schema

## Component Delegates

## component specifications

https://developer.mozilla.org/en-US/docs/Archive/Mozilla/Firefox/Style_System_Overview

Specifications are used to find a backing component for a lowkode placeholder, and customize it.




2

"About Face 3: The Essentials of Interaction Design", by Alan Cooper, has various chapters dedicated to user interface elements. The book uses these categories that I personally find appropiate and exhaustive:

Controls
Imperative controls (buttons, hyperlinks...)
Selection controls (check boxes, lists...)
Entry controls (spinneres, text edit...)
Display controls (scroll bars, splitters...)
Menus
Toolbars
Dialogs
Errors, alerts and confirmations