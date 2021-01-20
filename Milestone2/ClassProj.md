
## Summary of Our Approach to Software Development

    What processes are we following? ==> Disciplined Agile Delivery, Scrum, ...  What are we choosing to do and at what level of detail or extent?

## Initial Vision Discussion with Stakeholders
A web application for storing and displaying historical information about previous expeditions to various mountain peaks. They want information to be easily accessible and have an intuitive UI.

Here's the idea for this year.  It's a familiar one so you'll have a head start.  These **Hypothetical** ideas came from an informal discussion with the primary stakeholder:

[The Himalayan Database](https://www.himalayandatabase.com/) wishes to upgrade their website and make it a real web application where expeditions can submit their data far more easily.  In addition they wish to add features that leverage their data.  There's so much information in there that people could make use of that is now only possible for people with database or programming skills.  For example:
1. The public could browse or search for expeditions, climbers, dates, mountains, heights, etc. to learn more about them in a way that is far more user friendly than the existing features at /online.html.  
    - School children could gather data for class projects about the number of times Everest has been climbed within the last 25 years.
    - News organizations or book authors could gather information for their writing, such as for the deadly 1996 climbing season that prompted Jon Krakauer to write *Into Thin Air*.
    - Climbers could find unclimbed mountains, or peaks that haven't been climbed during Winter
    - and so much more
2. Expedition providers could much more easily enter their climbs and members into the database.  They might also be able to submit requests to update or correct previous entries.
3. Employees of The Himalayan Database could administer the site.
4. The site could be much more user friendly, showing dynamic information on the front page.
5. It would be great if it could serve as a hub for people to report on recent climbs or news.  To make it more trustworthy than other sources, they can utilize their relationships with famous climbers and outfitters.  i.e. this can be a trusted resource.
6. And lots more!

The data we used for the final last term came from: [rfordatascience/tidytuesday](https://github.com/rfordatascience/tidytuesday/blob/master/data/2020/2020-09-22/readme.md)

### List of Stakeholders and their Positions
   Professor Scot Morse because of class obligations.
   Users of the database.

## Initial Requirements Elaboration and Elicitation

### Elicitation Questions
#### Elicitation
1. Is the goal or outcome well defined?  Does it make sense?
The goal of the project is well defined and has a clear direction.
2. What is not clear from the given description?
The description gives little to no information about the desired format of the application.
3. How about scope?  Is it clear what is included and what isn't?
The scope of this project is the display and entry of information regarding mountain climbing expeditions.
    * Technical domain knowledge

Is the number 25 in requirement #1 arbitrary, or do you want specifically a page that shows the past 25 years of expeditions? If so, are there any other years that you want specified?
That specific number is indeed arbitrary and we could adjust the application to display information for any number of years so long as it does not exceed the data within the database.

Business domain knowledge

4. What do you not understand?
There are many variables within the database that we do not understand the purpose of.
5. Is there something missing?
6. Get answers to these questions.
 

#### Analysis
Go through all the information gathered during the previous round of elicitation.  

1. For each attribute, term, entity, relationship, activity ... precisely determine its bounds, limitations, types and constraints in both form and function.  Write them down.
2. Do they work together or are there some conflicting requirements, specifications or behaviors?
3. Have you discovered if something is missing?  
4. Return to Elicitation activities if unanswered questions remain.

### Elicitation Interviews
    Transcript or summary of what was learned

### Other Elicitation Activities?
    As needed

## List of Needs and Features
* Displaying present information
    1. Show information about a specific peak since a specified number of years
    2. Show death information from a specified year or time period
    3. List unclimbed mountains
    4. List treks that are in progress
    5. List treks that are planned for the future
    6. List information about members of a team
    7. Create teams and be able to manage their members (pt 2 might be admin)
    8. Display information about No Oxygen climbs 
        - and the people that did them
* Providers need to enter climbs and members easier
* Employees can administer the site
* Visitors and members can participate in forums about their travels

## Initial Modeling
    Diagrams

### Use Case Diagrams
    Diagrams

### Sequence Diagrams

### Other Modeling
    Diagrams, UI wireframes, page flows, ...

## Identify Non-Functional Requirements
1. English is the default language, but we must support visitors and data in other character sets
2. Following style rules
3. Formatting the displayed information in a readable and easily understandable manner
 

## Identify Functional Requirements (In User Story Format)

E: Epic  
U: User Story  
T: Task  
Ex:
 [U] As a visitor to the site I would like to see a fantastic and modern homepage that introduces me to the site and the features currently available.
 [T] Create starter ASP dot NET Core MVC Web Application with Individual User Accounts and no unit test project
[T] Choose CSS library (Bootstrap 4, or ?) and use it for all pages
[T] Create nice bare homepage: write initial welcome content, customize navbar, hide links to login/register
[T] Create SQL Server database on Azure and configure web app to use it. Hide credentials.
[T] Deploy it on Azure
[U] As someone who wishes to submit new information on an expedition I would like to be able to register an account so I will be able to use your services (once they're built)
[T] Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP, DOWN scripts
 [T] Configure web app to use our db with Identity tables in it
[T] Create a user table and customize user pages to display additional data
[T] Re-enable login/register links
[T] Manually test register and login; user should easily be able to see that they are logged in
[E] 
[U]
[T]
[T]
[U]
[T] Example end

1. [U]As a visitor to the site, I want to be able to see information about a specified peak within a specified time span, so that I can learn about the specified peak.
2. [U]As a visitor to the site, I want to see information about expeditions within a specified time span, so that I can look for interesting trends in data.
3. [U]As someone who is wanting to make an expedition, I want to see information about peaks based on some search criteria so that I can make my expedition my own.
4. [U]As a visitor to the site, I want to be able to see current and future expeditions, so I can feel invested in the journey.
5. [U]As a provider of information, I want to easily manage the members of an expedition that I created so that the form is easier to fill out.
6. [U]As a visitor to the site, I want to search the site with more options in a hidden tab so I can find expeditions or peaks with interesting information.
7. [U]As an employee, I want to edit database information so that I can correct incorrect information.
8. [U]As a visitor to the site, I want to be able to make a post in the site's forum so that I can communicate with others in the community.
9. [U]As a visitor to the site, I want to be able to comment on someone's forum post so that I can more specifically respond to them.
10. [U]As an employee, I want to delete someone's forum post so that I can keep the community on track and welcoming.

## Initial Architecture Envisioning
    Diagrams and drawings, lists of components

## Agile Data Modeling
    Diagrams, SQL modeling (dbdiagram.io), UML diagrams

## Timeline and Release Plan
    Schedule: meaningful dates, milestones, sprint cadence, how releases are made (CI/CD, or fixed releases, or ?)

