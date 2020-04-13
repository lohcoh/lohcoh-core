# lohr - User Stories To User Interfaces

lohr is an ASP.NET Core 'low code' development tool for creating user interfaces from user stories.

## Why lohr?
For a variety of reasons, there is currently a growing demand for 'low code' and 'no code' development tools.
This is a positive trend.
Meanwhile, in the world of Agile software development, User Stories are a very popular method of describing 
software features from an end user's perspective.
Lohr provides Product Owners, Business Analysts, Business Users with a new tool to jump-start the development of 
thier product that works the way they do... by writing user stories in natural language.

Lohr collects feature descriptions and user stories in 'feature documents', using 'structured english', one feature per document.
Given a collection of documents that describe a software system, lohr can analyse the documents and discover all the entities, 
relationships, rules, events, UI elements, test cases, etc, needed to understand the system.
lohr can then...
- build a model of the described system, and 
- from the model, generate a user interface and 'skeleton' backend code, and
- immediately deploy the system and make it available for verification and testing by stakeholders.

lohr generates a CQRS-oriented, Blazor-based web app and Web API controllers that a developer will interface with your internal services.
When a feature is deemed to be 'done', in an Agile sense, the resulting user stories and skeleton controllers are released to 
developers for completion.

## Calculator Example

As a software engineer
I want to create a software utility that can generate a complete working applicatioon from this feature description
so that I can prove that it's possible


Surface: Calculator 
    Has editable elements named Input1, Input2, and Result
    Has a button named Add

Feature: Addition
    In order to add two numbers
    As a math idiot
    I need a calculator that will tell me the sum of two numbers

Scenario Outline: Add two numbers
    Given a Calculator
    Given I have entered input_1 into Input1
    And I have entered input_2 into Input2
    When I press Add
    Then Result should be the sum of Input1 and Input2

    Examples:
    | input_1 | input_2 | button | output |
    | 20      | 30      | Add    | 50     |
    | 2       | 5       | Add    | 7      |
    | 0       | 40      | Add    | 40     |

## NOTES

lohr is a tool for creating CQRS-oriented, domain-driven applications.
When writing user stories

https://www.w3.org/TR/abstract-ui/#meta-model
