
# Concepts

## What is lowkode

lowkode is a rapid form development library for Blazor.  
It fully automates form UI creation by dynamically generating forms from models.  
lowkode is not tied to any particular UI library, it provides its own Bootstrap-based components but provides 
the ability to completely customize, transform, or replace any UI element. 

## Using lowkode in Razor templates
lowkode uses templates to model UI elements.
lowkode provides a special tag, &lt;lk&gt;, for creating models of UI elements.
The &lt;lk&gt; element defines a kind of 'slot' where content should be injected and the slot contains a model of a UI.  
The &lt;lk&gt; element will transform it's child content with customizations and extensions, possibly even completelty 
replacing the child content.

### Example
A typical Blazor component that displayed a form for editing a Customer would look something like this...

    <EditForm Model="@customer" OnValidSubmit="HandleValidSubmit">
      <DataAnnotationsValidator />
      <ValidationSummary />
      <FormGroup>
        <Label for="customer.Name">Name</Label>
        <InputText @bind-Value="customer.Name"/>
      </FormGroup>
      <FormGroup>
        <Label for="customer.Email">Email address</Label>
        <InputText @bind-Value="customer.Email"/>
        <Help for="customer.Email">We'll never share your email with anyone else.</Help>
      </FormGroup>
      <button type="submit">Submit</button>
    </EditForm>

Here's the same form using lowkode...

    <lk><EditForm Model="@customer" OnValidSubmit="HandleValidSubmit"/></lk>

The child content within the <lk> element defines *what* to display and how to connect it to the rest of the template.  
In this case we want to display an EditForm that displays a customer, and we want the final EditForm to invoke the HandleValidSubmit when the 
submit button is selected.  
lowkode will dynamically create a full featured instance of an EditForm component and inject it into the slot.  
The exact details of how lowkode generates content are discussed later, but basically lowkode replaces the content  
within <lk> slots with other, dynamically created, component instances, all based on model processors, model renderers, and components.


### Another Example
A lowkode slot can contain as little as a single element or an entire page.
Consider this partially completed form, the &lt;FormGroup&gt; elements lack details.


    <lk>
        <EditForm Model="@customer" OnValidSubmit="HandleValidSubmit">
              <DataAnnotationsValidator />
              <ValidationSummary />
              <FormGroup for="customer.Name"/>
              <FormGroup for="customer.Email"/>
              <button type="submit">Submit</button>
        </EditForm>
    </lk>

lowkode will extend the &lt;FormGroup&gt; elements with labels, input elements, validation rules, etc.
Out of the box, lowkode has model processors that can populate the &lt;FormGroup&gt; elements using information 
from the .NET Reflection API, Annotations, an Open API schema, and the lowkode Fluent Modeling API.

## How lowkode works

### Models, Processors, Renderers, and Components, oh my

### Processor and Renderer Pipelines

## Creating Model Processors

## Creating Model Renderer




