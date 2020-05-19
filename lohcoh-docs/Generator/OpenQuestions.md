# Open

## Is it possible to design a Blazor component where dependent and attached properties are set in a template?
Answer: I think the answer to this is that, since a site is totallt driven by context and metadata, that a developer 
should basically NEVER pass values to a component.
Sites are 'scoped' by wrapping them in Scope tags that set the appropriat environment for the site. 
        <Scope value=@lkContext.WithModelType(typeof(Starship)).WithModel(_starship) Context="modelContext">
            @foreach (var propertyMetadata in modelMetadata.Properties)
            {
                <Scope value=@modelContext.WithProperty(propertyMetadata) Context="propertyContext">
                    <p>
                        <label>
                            <DisplayName/>:
                            <Input/>
                        </label>
                    </p>
                </Scope>
            }
        </Scope>



# Resolved

## How to manage Context?
Background:  LowKode uses a metadata repository to store the metadata, components then use that metadata to generate content.  
Answer: Context objects will be a hierarchy ContextObjects.
The ContextObjects are arranged in a tree and inherit values from thier parents.
The lowkode context service provides a space-efficient implementation of ContextObjects

## Is it possible to create a Form component that you can inject form fields into?
	Seems like it's a mistake to make the rendering of a form dependent on the shape of some model object, because forms sometimes 
	need to be an aggregate of data items from several entity types, and being bound to the shape of some design-time 
	model totally doesn't work.
Answer: Yes, this is possible if we use DependentObjects instead of native .Net types.


## DataLog (a deductive database) is exactly the kind of system that should be used to manage metadata
Can a simple, C#-oriented library be implemented?
Yes:  Use value factory patterm (DependentObjects) and save internal data as some form of triplet.
This enables a basic datalog implementation to reason about the DependentObjects objects.
