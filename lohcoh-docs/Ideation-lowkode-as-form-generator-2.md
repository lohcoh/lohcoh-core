
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
lowkode is not an all-or-nothing proposition, suppose for some reason you wanted to explicitly build the form but didn't want to deal with building the details of each field we could do this...

    <lk>
        <EditForm Model="@customer" OnValidSubmit="HandleValidSubmit">
              <DataAnnotationsValidator />
              <ValidationSummary />
              <FormGroup for="customer.Name"/>
              <FormGroup for="customer.Email"/>
              <button type="submit">Submit</button>
        </EditForm>
    </lk>

In this case we're just asking lowkode to generate the field elements of the form.

### Example of Future Proofing
One more example, let's suppose we just want to future proof our form.
Let's suppose that we start with the form below, and wrap it in a lowkode slot just to future proof it...

    <lk>
        <EditForm Model="@customer" OnValidSubmit="HandleValidSubmit">
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
    </lk>

Notice that the above form does not contain the <DataAnnotationsValidator/> and <ValidationSummary/> elements.

Now, suppose that in the future we decide that we want to add attribute-driven validation to all our forms.
We can create a lowkode 'processor' will add the  <DataAnnotationsValidator/> and <ValidationSummary/> elements to 
any <EditForm> that doesn't have one.

The content that will eventually be injected into the original slot will look like this...
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


## How lowkode works

## Creating Model Processors

## Creating Model Renderer


## Open Questions

### Using Blazor compnents to specifiy a form model vs using a C# Fluent API for form modeling
    #### Advantages
        
    #### Disadvantages



