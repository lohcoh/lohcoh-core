# Technical Notes

## One Possible Implementation: UI Model + Context = metadata

Basic Workflow...
- Create UI Model using lohcode Blazor components
- On Startup in Blazor app, 

### Inspired by
	[MetaUI](https://www.metaui.io/) is an OK example of how to design a metadata-driven UI, but it's WAY complicated.
	[This article](https://hacks.mozilla.org/2017/08/inside-a-super-fast-css-engine-quantum-css-aka-stylo/) shows 
	how a rule engine (that applies selectors to a DOM) works.


	
## Customization Stories
- Add an item to a navigation menu for a particular customer
- Highlight a number in a table if it's above a certain number
	- Rule-driven pipe (angular pipe)?
- Change form layout based on customer
- Call different endpoint based on tenant (this is probably better handled by server)
- Enable features if user paid for Enterprise Edition


## component specifications

https://developer.mozilla.org/en-US/docs/Archive/Mozilla/Firefox/Style_System_Overview

Specifications are used to find a backing component for a lowkode placeholder, and customize it.


## Idea for reactive rule engine
rules are invoked when thier dependencies change.
A rule is a triplet of functions; dependents, a and ...

/**
 * For Initech users, set the application title
 */
new Rule() {
	Properties: _=> new { Title: meta.App.Title },
	Context: new { CompanyId: ctx.CurrentUser.CompanyId },
	When: vars => vars.CompanyId == "ibm_selectric_accounting",
	Then: props => props.Title="TPS Reports"
};

// ding ding ding, I think this is doable and it's the simplest possible
new Rule((ctx,meta) => { 
	if (ctx.CurrentUser.CompanyId == "ibm_selectric_accounting")
		meta.App.Title = "TPS Reports";
}

the above gets translated to this equivalent code...

(ctx,meta) => {
	ctx.CurrentUser.Events.Select(user => user.CompanyId == "ibm_selectric_accounting")
		.Then(() => meta.App.Events.Post(app => app.Title = "TPS Reports"));
}



/**
 * For IBM users, set the URL to products thumbnails
new Rule()
	.Metadata(meta => meta.App..Items)
	.Context(ctx => new {
		CompanyId: ctx.CurrentUser.CompanyId
	})
	.When(vars => vars.CompanyId == "ibm_selectric_accounting")
	.Then(meta => meta.App.Navigation.Items.AddItem(new Item("TSR Reports")));
	

whose parameters declares its dependent properties in the context tree 
When a rule's antecendent evaluates to true then the rule changes the
