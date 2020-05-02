# Links

## dotnet architecture 
[Sample ASP.NET Core 3.0 reference application](https://github.com/dotnet-architecture/eShopOnWeb), 
demonstrating a layered application architecture with monolithic deployment model. 
[Download 130+ page eBook PDF from docs folder.](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/index)

[Here's a good example](https://wildermuth.com/2018/01/10/Re-thinking-Running-Migrations-and-Seeding-in-ASP-NET-Core-2-0) of why convention-driven APIs are magical crap that nobdy can figure out.
This guy, obviouslt an expert .NET core developer, made two attempts configure EF seeding and failed until he figured out the conventions encoded into the .NET core startup APIs.


## Technical Information
[Overview of ASP.NET Application Parts](https://docs.microsoft.com/en-us/aspnet/core/mvc/advanced/app-parts?view=aspnetcore-3.0)
This library 

A library for managing feature flags: 
[Microsoft Feature Flags](https://github.com/microsoft/FeatureManagement-Dotnet)

[Good reference for ef core](https://www.learnentityframeworkcore.com/dbcontext)

[A Model-Driven Approach to Graphical User Interface Runtime Adaptation](http://ceur-ws.org/Vol-641/paper_15.pdf)
  
[More info on DDD design in eShopOnWeb](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implemenation-entity-framework-core)

[Business Rules in User Interfaces](http://www.brcommunity.com/articles.php?id=b378)

https://openrules.wordpress.com/2018/10/17/openrules-customer-is-a-winner-of-the-2018-business-rules-excellence-awards/

## Related Products

[React library that creates forms from JSON schemas](https://uniforms.tools/docs/uth-bridge-concept)
[Another react forms from schema generator, popular](https://github.com/rjsf-team/react-jsonschema-form)
https://github.com/udos86/ng-dynamic-forms
https://angular.io/guide/dynamic-form#bootstrap

https://www.orbeon.com/

[A lowcode development tool based on Vue](retool.com)

[A description of using attributes in domain driven design](https://www.researchgate.net/publication/311980398_Domain-driven_design_patterns_A_metadata-based_approach)

[Box](http://box.com)

[Window Forms made extensive use of design-time attributes](https://flylib.com/books/en/1.41.1/)

### Windows Template Studio
https://github.com/Microsoft/WindowsTemplateStudio
https://www.infoq.com/news/2018/08/UWP-LOB-Win10/
https://www.youtube.com/watch?time_continue=7&v=4chzzzAZRNQ&feature=emb_logo


[Blazor UI grid that uses metadata](https://github.com/gustavnavar/Grid.Blazor)
    [This sample app shows how Grid.Blazor configures components with a delegate that handles client side operations](https://github.com/gustavnavar/Grid.Blazor/blob/master/GridBlazorClientSide.Client/Pages/GridButtons.razor)
    This would be a useful approach for providing lowkode components with thier delegates



https://camel.apache.org/manual/latest/roundRobin-eip.html

### DDD Frameworks
http://seedstack.org/docs/business/policies/

### Articles on schema-driven UI development

[Design system and API-Driven UI](https://getaround.tech/mobile-api-driven/)
Conclusion: ```we definitely think that on a long terms basis, it’s a valuable and powerful tool for quickly building a new feature, in a scalable way.```

[Using GraphQL & Backend-Driven UI, to build faster with less code](https://medium.com/novvum/using-graphql-backend-driven-ui-to-build-faster-with-less-code-5c13d7154d99)
Conclusion: 
```
So, what benefits did we receive from this pattern?
- More consistent and enjoyable developer experience across teams. Now, developers don’t have to re-implement the same code across every client. No more worrying about the design and copy requirements individually, the API handles it!
- Reduced frontend code. The project had been worked on by numerous developers and had to handle all of the status logic prior to rendering! There was a ton of unnecessary logic transforming these statuses into the right wording and design patterns. Now, we have removed all of that code equating to hundreds of lines!
- More consistent user experience! Most importantly, is the benefit this has had on user experience. Now, users and admins receive consistent communication across all frontend clients and transactional messaging
```


