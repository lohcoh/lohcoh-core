
# Concepts

## What is lowkode

lowkode is a rapid form development library for Blazor, it fully automates form creation by dynamically generating forms from metadata.  
More specifically, lowkode is a Blazor template processor that can use metadata to transform Razor templates.

lowkode can...
- generate a complete form for a given .NET Type.
- make cross-cutting changes to your UI.
- keep business rules out of your UI code.

lowkode is not tied to any particular UI library, it provides its own Bootstrap-based components but provides 
the ability to completely customize, transform, or replace any UI element. 

## Using lowkode in Razor templates
lowkode provides a special tag, &lt;lk&gt;, for applying lowkode to your Blazor templates.  
The &lt;lk&gt; element defines a kind of 'slot' that will transform it's child content with customizations and extensions, possibly even completely 
replacing the child content.  

### Example
A typical Blazor form for editing a Starship object looks something like this...

        @page "/FormsValidation"

        <h1>Starfleet Starship Database</h1>

        <h2>New Ship Entry Form</h2>

        <EditForm Model="@_starship" OnValidSubmit="HandleValidSubmit">
            <DataAnnotationsValidator />
            <ValidationSummary />

            <p>
                <label>
                    Identifier:
                    <InputText @bind-Value="_starship.Identifier" />
                </label>
            </p>
            <p>
                <label>
                    Description (optional):
                    <InputTextArea @bind-Value="_starship.Description" />
                </label>
            </p>
            <p>
                <label>
                    Primary Classification:
                    <InputSelect @bind-Value="_starship.Classification">
                        <option value="">Select classification ...</option>
                        <option value="Exploration">Exploration</option>
                        <option value="Diplomacy">Diplomacy</option>
                        <option value="Defense">Defense</option>
                    </InputSelect>
                </label>
            </p>
            <p>
                <label>
                    Maximum Accommodation:
                    <InputNumber @bind-Value="_starship.MaximumAccommodation" />
                </label>
            </p>
            <p>
                <label>
                    Engineering Approval:
                    <InputCheckbox @bind-Value="_starship.IsValidatedDesign" />
                </label>
            </p>
            <p>
                <label>
                    Production Date:
                    <InputDate @bind-Value="_starship.ProductionDate" />
                </label>
            </p>

            <button type="submit">Submit</button>

            <p>
                <a href="http://www.startrek.com/">Star Trek</a>, 
                &copy;1966-2019 CBS Studios, Inc. and 
                <a href="https://www.paramount.com">Paramount Pictures</a>
            </p>
        </EditForm>

        @code {
            private Starship _starship = new Starship();

            private void HandleValidSubmit()
            {
                Console.WriteLine("OnValidSubmit");
            }
        }

Here's the same form using lowkode...

        @using Lowkode.Client.Core
        @page "/FormsValidation"

        <h1>Starfleet Starship Database</h1>

        <h2>New Ship Entry Form</h2>
        
        <lk><EditForm Model="@_starship" OnValidSubmit="HandleValidSubmit"/></lk>            

        @code {
            private Starship _starship = new Starship();

            private void HandleValidSubmit()
            {
                Console.WriteLine("OnValidSubmit");
            }
        }

    
Notice that the EditForm element has been wrapped with &lt;lk&gt; tags.  
The &lt;lk&gt; component transforms its child contents using the lowkode Transformation service to add and modify template contents.
Out of the box, the lowkode &lt;lk&gt; component will extend the contained EditForm component with field elements for all the public properties defined by the Starship type.
The exact details of how lowkode generates content are discussed later, but basically lowkode replaces the content  
within <lk> slots with other, dynamically created component instances, all based on 'transformers' and components.

Also notice that the lowkode version of the Starship form doesn't contain the copyright notice at the bottom of the form, that's because the copyright's been moved elsewhere.  
With lowkode, if you want to put a copyright notice at the bottom of all your forms you don't do it by putting a copyright notice at the bottom of all your forms, that's hard to maintain.  
Instead, you create a Copyright component and a Transformer that adds the Copyright to the bottom of all your forms.

lowkode comes with transformers that can populate an &lt;EditForm&gt; element using information 
from the .NET Reflection API, Annotations, an Open API schema, or the lowkode Fluent Modeling API.
Developers can add thier own transformers to lowkode.



## How lowkode works



### Models, Processors, Renderers, and Components, oh my

### Processor and Renderer Pipelines

## Creating Model Processors

## Creating Model Renderer




