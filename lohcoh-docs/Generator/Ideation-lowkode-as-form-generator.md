
# Concepts

## What is LowKode

LowKode is a library designed to make it easy to use metadata to build a UI.

LowKode can be used in many ways...
- LowKode can fully automate form creation, or just make your current forms easier to maintain.  
- LowKode can also automate the construction of grid and tables, menus, navigation, etc.
- help keep business rules out of your UI code.

LowKode is not tied to any particular UI library, out-of-the-box LowKode uses Radzen Blazor components, but LowKode can use any UI library.


## Example
In this example we'll modify an example form from the Microsoft Blazor documentation.
The example is a basic Blazor form, we'll eliminate a lot of code by rewriting it using LowKode.
Here's the example form from the Microsoft site...

        @page "/FormsValidation"

        <h1>Starfleet Starship Database</h1>

        <h2>New Ship Entry Form</h2>

        <EditForm EditContext="@_editContext" OnValidSubmit="HandleValidSubmit">
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
            private EditContext _editContext;

            protected override void OnInitialized()
            {
                _editContext = new EditContext(_starship);
            }

            private async Task HandleSubmit()
            {
                var isValid = _editContext.Validate();

                if (isValid)
                {
                   Console.WriteLine("OnValidSubmit");
                }
     
            }          
        }

The form above has some nice things going for it, it uses &lt;DataAnnotationsValidator /&gt; and &lt;ValidationSummary /&gt; 
to automagically configure validations and display the results of validations.   
That stuff would be better put into a base form class so that you don't have to do that everywhere.  
So instead of using &lt;EditForm&gt; we would use something like &lt;MyBaseFrom&gt;, but this is just an example so it's no problem here.

And the copyright notice at the bottom would be better if it were encapsulated in a component, again, no biggie since this is an example.

But what about all the field definitions?  
Blazor gave us convenient components for automagically handling validation, why isn't there a component that will automagically create all the fields?

Well now there is, here's the same form using LowKode...

        @using LowKode.Client.Core
        @page "/FormsValidation"

        <h1>Starfleet Starship Database</h1>

        <h2>New Ship Entry Form</h2>
        
        <EditForm EditContext="@_editContext" OnValidSubmit="HandleValidSubmit">
            <DataAnnotationsValidator />
            <ValidationSummary />

            <EditFields Context="field">
                <FieldTemplate>
                    <p>
                        <label>
                            @field.Metadata.DisplayName+":"
                            @field.EditComponent
                        </label>
                    </p>
                </FieldTemplate>
            <EditFields>

            <button type="submit">Submit</button>

            <p>
                <a href="http://www.startrek.com/">Star Trek</a>, 
                &copy;1966-2019 CBS Studios, Inc. and 
                <a href="https://www.paramount.com">Paramount Pictures</a>
            </p>
        </EditForm>

        @code {
            private Starship _starship = new Starship();
            private EditContext _editContext;

            protected override void OnInitialized()
            {
                _editContext = new EditContext(_starship);
            }

            private async Task HandleSubmit()
            {
                var isValid = _editContext.Validate();

                if (isValid)
                {
                   Console.WriteLine("OnValidSubmit");
                }
     
            }          
        }

Notice that we've replaced all the field declaration with the LowKode <EditFields> component.  
The <EditFields> component can enumerate all the properties in a .Net type and automagically populate templates with appropriate input elements for each property.  
In this case, the <EditFields> component will extend the EditForm component with field elements for all the public properties defined by the Starship type.  

The other thing that LowKode is doing in this example is automagically constructing the appropriate input component for each property, that's this line...  
    @field.InputComponent  
During Startup, LowKode is configured with data that maps data and object types to Blazor components used to display and edit those types.  
When using LowKode to creating a form, you don't have to know the details of how to create an input element for each field, LowKode can do that for you.  
In fact, if we registered the <FieldTemplate> element from the example with LowKode then we could reduce the EditFields element in the example to this...  
    <EditFields/>  
          
### Extensible set of metadata providers
LowKode comes with extensions that provide LowKode components with metadata from the .NET Reflection API, .NET Annotations, an Open API schema, and even third-party libraries like FluentValidation.
Developers can use their own source of metadata by adding thier own extensions to LowKode.


### Create your own metadata-driven Blazor components
Developers can also use LowKode's Metadata API to create thier own metadata-driven Blazor components.



## How LowKode works


### Models, Processors, Renderers, and Components, oh my

### Processor and Renderer Pipelines

## Creating Model Processors

## Creating Model Renderer




