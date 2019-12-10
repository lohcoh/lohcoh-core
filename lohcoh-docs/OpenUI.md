# OpenUI

OpenUI is our name for our OpenAPI extensions for describing web-based UIs.

## Concept
OpenAPI is used to describe everything a third-party needs to consume your REST web services.  
What if that third-party wants to *display* that data?  
There's already a lot of information in an OpenAPI document that can be used to automatically display data provided by a web service.
OpenUI extends OpenAPI with additional metadata

These web services are comprised of a set of URI (paths) that consume and produce JSON objects.

Similarly, a web application can be thought of as a set of URI (paths) that consume and produce HTML objects.
An OpenAPI document also specifies all the metadata you need 