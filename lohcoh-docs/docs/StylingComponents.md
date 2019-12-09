# styling

## notes
Specification properties and metadata properties are modeled as classes, like in semantic modeling systems.
This is because the properties 

## rants

This rant was inspired by [this history of CSS design systems](https://medium.com/@perezpriego7/css-evolution-from-css-sass-bem-css-modules-to-styled-components-d4c1da3a659b)

The idea of constructing user interfaces from metadata has been around for a long time.
Constructing user interfaces from metadata is a simple and compelling idea but it hasn't 
caught on in the development community.  
I think the reason for that is that the languages and methods that have been invented for 
defining a UI in terms of metadata are not easy to understand or use.  

It's not enough to design a system that uses metadata to generate user interfaces.  
lowcode is meant to be a tool that makes it *easy* to 'style' applications using metadata.  
Therefore, it's crucial that the API that the developer uses to style application be easy to 
understand and use, that's a challenge.

Consider the history of CSS, in the early days it's was damn near impoosible to consistently 
style an application with CSS, muchless reuse CSS in any way,  
But using CSS was not a choice, so over the years many 'design-systems' for CSS have been 
invented.  The design of lowkode's styling system applys the lessons learned from decades of 
using CSS.

We can turn to CSS for an example of how create a comprehensible style system.
There's a reason there are so many CSS design systems, coming up with an easy to understand way 
of declaring style information is difficult.  CSS design systems have evolved over the years 
based on the lessons learned attempting to properly manage an application's style.  
In the early days, there were no ways of consistently styling applications in a comprehensible way.  
If lowkode's styling system was based on a simple CSS-like system of applying metadata to components 
then we could expect to have all the same problems that developers had with CSS in the early days.
CSS needed a way to structure rules in a consistent way that reduced complexity.

An early inovation in the CSS space as SASS. SASS provided developers with a more convenient way 
to structure CSS rules, but it didn't really provide a way to reduce the complexity of large sets of 
CCS rules.

The BEM methodology was the next inovation. BEM introduced a way of naming elements based on class names.
BEM introduced 'semanticity' to CSS.  
This made it possible for developers to think in term of components, thus makign it easier for develoeprs 
to understand and maintain a large set of CSS rules.  
BEM had shortcoming though, it wasn;t a true component-oriented system, you needed to explicitly 
extend every ui component whenever you wanted to reuse in a different context.
Again, if lowcode adopted a BEN-like approach to styling then we could expect to have the same problems.

Styled-Components is a recent innovation 






        /// <summary>
        /// The core lowkode components are place-holders for UI parts that are created at runtime.
        /// A placeholder component gives the UI engine a 'specification' of the part that it needs and 
        /// the engine returns a part that fulfills the specification.
        /// 
        /// The specification 
        /// 
        /// The most basic parts of a specification are...
        /// 
        /// - The view model.  What kind of object does the part display?
        /// 
        ///     The ModelType property denotes the kind of object displayed by the part
        ///     
        /// - What kind of UI elememnt is needed?
        /// 
        ///     User interface elements usually fall into one of the following four categories:
        ///     - Input Controls
        ///     - Navigation Components
        ///     - Informational Components
        ///     - Containers
        ///     
        ///     The ElementType property denotes the element type.
        /// 
        /// 
        ///     The same object can be displayed many different ways.
        ///     For instance, a Cusomter can be displayed in a grid, in a form, in a card.
        ///     Each display is different.
        ///     A lowkode component type demotes the kind of part needed.
        ///     For instance, <DisplayTable> denotes a grid-like component, a <Card> denotes an abbreviated, non-editable view of an object, etc.
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="modelType"></param>
