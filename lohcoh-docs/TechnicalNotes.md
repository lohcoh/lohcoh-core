# Technical Notes

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