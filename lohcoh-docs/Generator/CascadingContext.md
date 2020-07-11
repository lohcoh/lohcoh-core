# Cascading Context

## Render Pipeline
Currently Lowkoder can generate a simple form using the EditFields component, which uses it's child content template to generate each field.
Within the field template, Lowkode 'slot' components are used to render lowkoder-generated elements into the template.
In order for lowkoder to generate those elements, properties that tell lowkoder what content to generate must be passed from the 
EditFields component, down through the field template to the slot component.
It's possible to automatically wire-up these components and so it should be done automatically, rather than make a developer 
do code it.
Lowkoder uses a mechanism called 'cascading context' for passing data through a component tree.
Cascading context works somewhat like CSS in that...
- components can inherit properties from thier parents, *and* 
- components can change the values of the properties it inherits and pass those new values on to it;s ancestors, *and*
- rules can change the values that a component inherits.

In order to implement cascading context it's necessary to be able to discover the ancestral relationships between components, 
something that's not easy to do in Blazor.
Lowkoder uses a technique that it calls a 'render pipeline' to tap into the rendering, and ultimately the construction of, 
components.
Among other things, the Lowkoder render pipeline can be used to inject arbitrary attributes into components as they are rendered.
The lowkoder cascading context mechanism uses the render pipeline to inject metadata into components 
that's used by the lowkoder cascading context API.

PS: The render pipeline is also used by the lowkoder event bus.