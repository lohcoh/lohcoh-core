# Cascading Context

Lowkoder provides a sophisticated Cascading Parameter API that it calls 'Cascading Context'.
Like the Blazor Cascading Parameters API, the Lowkoder Cascading Context API is used to pass data through a component hierarchy.
In addition, the Cascading Context API is designed to...
- make it easy and efficient to cascade complex object types
- make it possible to filter the values inherited by components with external rules.  Lowkoder calls this 'Context-Driven Parameters'.
- make it possible to segregate component extensions and customizations from the UI.

## Implementation

The Cascading Context API provides a mechanism that maps objects and thier values to named Cascading Parameters.
This mechanism efficently stores large objects as Cascading Parameters.
In addition, it provides a typed, object-based interface for accessing and changing cascading values instead of using Types and string-based labels.
The Cascading Context API is similar to Entity Framework in that it mapes operations on object to and underlying 

## Render Pipeline
Currently Lowkoder can generate a simple form using the EditFields component, which uses it's child content template to generate each field.
Within the field template, Lowkoder 'scoped' components are used to render Lowkoder-generated elements into the template.
In order for Lowkoder to generate those elements, parameters that tell Lowkoder what content to generate must be passed from the 
EditFields component, down through the field template to scoped component.
It's possible to automatically wire-up these components and so it should be done automatically, rather than make a developer code it.
Lowkoder uses a mechanism it calls 'cascading context' for passing data through a component tree.
Cascading context works like CSS in that...
1. components can inherit properties from thier parents, *and* 
2. components can change the values of the properties it inherits and pass those new values on to it's ancestors, *and*
3. external rules can change the values that a component inherits.

(1) and (2) are features that are also provided by Cascading Parameters.
(3) is a feature provided by Lowkoder.

