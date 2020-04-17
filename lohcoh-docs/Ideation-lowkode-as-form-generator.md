# Concepts

## What is lowkode



lowkode is a rapid form development library for Blazor that uses metadata to fully automate form contruction.
lowkode is not a UI component library, it constructs forms using components from a *component library*.
lowkode comes with a variety of component library that you modify or extend with your own components.

lowkode is not tied to any particular UI library, it can use whatever you're using.
Out of the box support is provided for all popular UI libraries including Material, ngx-bootstrap, NG Bootstrap, Foundation, Ionic, Kendo and PrimeNG.g, transforming, and composing Blazor UI components into higher level UI elements 
using metadata, business rules, and runtime data.
lowkode is the easiest way for developers to build, customize, extend, and maintain a user interface for line of business applications.

lowkode does three things...
	- it maps data and objects to UI components 		
	- it dynamically generates many kinds of high level UI elements, like forms, data tables, search panels, navigation menus, etc.
	- it give developers the ability to completely customize, transform, or replace any UI element contained within a lowkode 'slot'. 

## Using lowkode components in Razor templates
lowkode provides a special tag, <lk>, for identifying content that should be enhanced or replaced by lowkode.
The <lk> element defines a special kind of 'slot'.  
The child content within the slot defines *what* to display and how to connect it to the rest of the template. 
The <lk> element will transform it's child content with customizations and extensions, possibly even completelty 
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
lowkode will, among other things, use the .NET Reflection API and Attributes to create the form.
The exact details of how lowkode generates content are discussed later, but basically lowkode replaces the component instances defined 
within <lk> slots with other, dynamically created, component instances, all based on rules and templates.
One of lowkode's secret weapons is that it provides some crazy cool ways to generate and transform content using templates.


### Another Example
If for some reason we wanted to explicitly build the form but didn't want to deal with building the details of each field we could do this...

     <EditForm Model="@customer" OnValidSubmit="HandleValidSubmit">
          <DataAnnotationsValidator />
          <ValidationSummary />
          <lk><FormGroup @bind-Value="customer.Name"/></lk>
          <lk><FormGroup @bind-Value="customer.Email"/></lk>
          <button type="submit">Submit</button>
    </EditForm>

In this case we're just asking lowkode to generate the field elements of the form.


We could also write the previous form this way, wrapping the entire form in a lowkode slot.
lowkode will apply all available transformations to the content within the slot, so the FormGroups still get expanded...
    <lk>
        <EditForm Model="@customer" OnValidSubmit="HandleValidSubmit">
              <DataAnnotationsValidator />
              <ValidationSummary />
              <FormGroup @bind-Value="customer.Name"/>
              <FormGroup @bind-Value="customer.Email"/>
              <button type="submit">Submit</button>
        </EditForm>
    </lk>

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
We can created a lowkode 'rule' and a template that will add the  <DataAnnotationsValidator/> and <ValidationSummary/> elements to 
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



## Using lowkode components in Razor templates




