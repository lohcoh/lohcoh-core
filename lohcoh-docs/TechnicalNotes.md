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

Rules subscribe to property events and are fired when conditions match.
LowKode can make rules more efficient by inspecting the When expressions and 
building it's own indexes to reduce the # of When expressions that need to be 
executed on a property change


// All Initech rules...
.When(ctx => ctx.User.CompanyId == "initech")
.Then(meta => {
	meta.App.Title = "TPS Reports 5000";	

	// Add TPS widgets to the dashboard
	meta.App.Dashboard.Widgets.Add<TpsReportsWithNoCoverSheetDashboardWidget>();
	meta.App.Dashboard.Widgets.Add<LateTpsReportsDashboardWidget>();
});

.When((ctx,meta) => ctx.Site.ModelType == meta.ForSystemType<TPSReport>())
.Then(meta => {
	// when displaying a TPSReport in a form then make the submit button extra large
	meta.UI.Widgets.Buttons.Submit.DefaultSize = meta.UI.Widgets.Buttons.Sizes.ExtraLarge;
		
	// when the form is submitted, display a notice to remind the user to also create a cover sheet
	// The code below is adding a handler to the Submit Button's global metadata.
	// These handlers get added to every Submit button created, but only in the contexts to 
	// which the Rule is applyed.  In this case, ModelType is only equal to TPSReport when 
	// a site is displaying or editing a TPSReport.
	meta.Widgets.Buttons.Submit.OnClick += () => {
		meta.App.Services.Notifications.Post("Don't forget to add a cover sheet m'kay....")
	};
});

