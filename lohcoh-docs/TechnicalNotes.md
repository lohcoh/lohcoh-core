﻿# Technical Notes

## One Possible Implementation: UI Model + Context = metadata

Basic Workflow...
- Create UI Model using lohcode Blazor components
- On Startup in Blazor app, 

### Inspired by
	[MetaUI](https://www.metaui.io/) is a good eample of how to design a metadata-driven UI  
	[This article](https://hacks.mozilla.org/2017/08/inside-a-super-fast-css-engine-quantum-css-aka-stylo/) shows 
	how a rule engine (that applies selectors to a DOM) works.
	



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