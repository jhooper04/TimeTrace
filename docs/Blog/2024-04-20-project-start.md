# Time Trace Project Begins

Time trace is an open source software development bug tracker and time tracker for software project managemnet and record keeping for an independent contractor.
The project will be built using Asp.Net Core 8.0, MariaDb, and a standalone blazor frontend based on material design using MudBlazor.

## Project Vision

The main features of this project will be to enable project management by allowing a manager to manage clients, their contacts, and client projects. Each project
will have a series of associated features. A project will have a series of contracts where each contract consists of the following phases and each has its own deliverables:

1. Quote - Ideas are translated into subdomains and feature specifications. Each feature is quoted for its complexity for a rough estimation of the total project contract cost.

2. Design - Features are broken down into user stories with entity relation diagrams, sequence diagrams, and use case diagrams. The techonology and architecture decisions are made, 
and user stories are organizaed into sprints. A detailed estimate of costs for each sprint is created and development is ready to begin.

3. Sprint - Half of the sprint is charged and implementation begins with the rest charged at delivery based on the design estimates of the previous phase. At the conclusion of the sprint
one or more features go through acceptance testing by the client. If there are multiple sprints, the next sprint begins. While working on a story, time spent on it is recorded and 
the client can log in to view the status of the sprint's completion of user stories and have access to a development deployment with continous integration. 

4. Delivery - The software solution is deployed or delivered and the contract is marked as complete.

## Architecture design decisions

The system will be containerized with docker, consisting of a web-api, database, and frontend client. The architecture will be a clean architecture based on (this tmeplate)[https://github.com/jasontaylordev/CleanArchitecture/blob/main/README.md] 
modified with a vertical feature slice approach and domain driven design. The project will also be fully implemented using test driven development for automated testing.

Clean architecture usually consists of the following layers: WebUI, Infrastructure, Application Core, and Domain. With the vertical feature slices approach those same layers are 
logically maintained but the layers are within a single core application project so that all the relevant classes for a feature can be grouped together logically.