# lohr - Executable User Stories 

## Vision
- Use structured english to generate a user interface
- Execute user stories written in structured english
- Use structured english to build a user interface
- Use structured english to build a user interface


## Vision
As a product owner, charged with creating a a web-based interface to a service, you want to be able 
to verify that you have faithfully captured all the user stories needed to create a product that your all stakeholders will love.
What better way is there to do that than to demonstrate the product to your stakeholders before you start development?
Wait, what?  How can I do that, you ask?

Use lohr to write your user stories, lohr can translate user stories written in 'Structured English' into a working application.
At any time, you can execute your user stories to validate your work and/or get feedback from stakeholders.

lohr is a web application for writing user stories.  
lohr provides an enhanced editor for writing user stories in 'Structured English'.
lohr also provides features for organizing and analyzing stories.
lohr projects are just folders and text files, you can sync them to git or whatever.
When your stories are done, export them to DevOps or Jira.




## Vision
lohr is an extension of SpecFlow that can generate scaffolds of system elements, or a complete system, from specifications.

lohr is a tool for capturing the requirements of a domain-driven software system, and building a model of the system 
in such a way that the resulting model can be used to generate a complete working system.
The model created by lohr describes all the usual elements of CQRS-oriented, domain-driven software system: entities, application services, commands, specifications, value objects, and even UI components.
In addition, lohr's model also captures behavioral aspects of the system.
lohr models are a collection of text documents written in an extended version of the Gherkin language.


Using a model, lohr generates code for all the usual elements of a ASP.NET Core, CQRS-oriented, domain-driven application: entities, aggregates, services, repositories, commands, specifications, value objects, APIs, and even UI components.
lohr's generated code is highly customizable and extensible.
lohr's generates a complete UI for the system.  
Alternately, lohr's Blazor-based UI component's are easily integrated into other ASP.NET UI applications.

## lohr User Stories

### Story: Support For Product Discovery(Story Storming)
As a Product Owner
I am charged with creating a software system that satisfies some business need 
therefore, I want a simple, flexible, easy way to describe a software system to be implemented with lohr's runtime engine





## Exercise - Map a User Story to an executable domain-driven model
Is it possible to use 
Use this example from the SpecFlow tutorial...

    Feature: Calculator
           In order to avoid silly mistakes
           As a math idiot
           I want to be told the sum of two numbers

    @mytag
    Scenario: Add two numbers
           Given I have entered 50 into the calculator
           And I have also entered 70 into the calculator
           When I press add
           Then the result should be 120 on the screen


## Another example 

Scenario: User supplies correct user name and password
Given that I am on the sign-in page
When I enter my user name and password correctly
And click ‘Sign In’
Then I am taken to the dashboard

Scenario: User does NOT supply correct user name and password
Given that I am on the sign-in page
When I enter my user name and password incorrectly
and click ‘Sign In’
Then I see an error message ‘Sorry, incorrect user name or password.”

## Yet Another Example
 Feature: Browsing
        In order to see who's been on the site
        As a user
        I want to be able to view the list of posts

    Scenario: Navigation to homepage
        When I navigate to /Guestbook
        Then I should be on the guestbook page

    Scenario: Viewing existing entries
        Given I am on the guestbook page
        Then I should see a list of guestbook entries
            And guestbook entries have an author
            And guestbook entries have a posted date
            And guestbook entries have a comment

    Scenario: Most recent entries are displayed first
        Given we have the following existing entries
            | Name      | Comment      | Posted date       |
            | Mr. A     | I like A     | 2008-10-01 09:20  |
            | Mrs. B    | I like B     | 2010-03-05 02:15  |
            | Dr. C     | I like C     | 2010-02-20 12:21  |
          And I am on the guestbook page
        Then the guestbook entries includes the following, in this order
            | Name      | Comment      | Posted date       |
            | Mrs. B    | I like B     | 2010-03-05 02:15  |
            | Dr. C     | I like C     | 2010-02-20 12:21  |
            | Mr. A     | I like A     | 2008-10-01 09:20  |

## Related Links

[Domain Storytelling](https://domainstorytelling.org/)
This site 

[SpecFlow](https://specflow.org/)


