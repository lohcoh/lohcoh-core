﻿# How lowkode works

Here's a simplified version of the code for the lowkode &lt;lk&gtl component...
    
    @inject LowkodeTransformationService lowkode

    @GeneratedContent

    @code {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            GeneratedContent= lowkode.ApplyTransformations(ChildContent);
        }
    }


The &lt;lk&gt; element transforms the RenderFragment that represents its child content into a new RenderFragment that's generated by the lowkode Transformation service.  
The Transformer service is a tool for programatically rewriting Blazor templates using Transformers.
A Transformer takes a RenderFragment and changes it in some way, the most common transformation is to add content.
The Transformer service can be extended with new Transformers.

The Transformer service arranges the Transformers in a pipeline, passing the output from one Transformer to the next.
lowkode is configured with a set of Transformers in Setup.ConfigureServices.
