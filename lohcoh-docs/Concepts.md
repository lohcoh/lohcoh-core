# Concepts

## What is lowlode

lowkode is library for dynamically composing Blazor UI components into higher level UI elements 
using metadata, business rules, and runtime data.
lowkode is the easiest way for developers to build, customize, extend, and maintain a user interface for line of business applications.

lowkode does three things...
	- it maps data and objects to UI components 		
	- it dynamically generates many kinds high level UI elements, like forms, data tables, search panels, navigation menus, etc.
	- it give developers the ability to completely customize or replace any UI element contained within a lowkode-based component. 

## Using lowkode components in Razor templates
Inversion of control is one of lowkode's central concepts.
In terms of building an application with Blazor, inversion of control means that components do not instantiate thier own child components.
Instead, components have child components injected into them, at a site of the parent component's choosing.

Here's an example...
A typical Blazor component that displayed a Customer would look something like this...

<form>
  <div class="form-group">
    <label for="exampleInputEmail1">Email address</label>
    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
  </div>
  <div class="form-group">
    <label for="exampleInputPassword1">Password</label>
    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
  </div>
  <div class="form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
</form>

### Mapping data and objects to UI components


### Dynamically generating UI elements, like forms

### customize or replace any UI element 

#### Inversion of Control in a UI






