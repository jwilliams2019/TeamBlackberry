# As a visitor to the site, I want to search for information about expeditions within a specified time span, so that I can look for interesting trends in data.

## ID: 3
## Effort Points: 1
## Owner: Hayden Orn
## Feature branch name: Milestone4

## Assumptions/Preconditions
It is assumed CRUD functionality has been built into the project.

## Description
This will be a new page that will let the user input two things, a starting date/time and an endint date/time, and will show all expiditions in a table within that timeframe.


Include links to modeling diagrams or anything else referenced or needed to complete this story.

## Acceptance Criteria
[Try to write criteria that, when true or satisfied mean that it is correct and you're done. Write them in the "If ___ then ____" format, for if you do this then you should expect this result, for defining the correct behavior that shows the feature works as requested]

1. If I choose a start and end date and press submit then the program must return a list of all expeditions between those dates.
2. If I choose an end date that is before my start date then it must display no data.

## Tasks
1. Create US3 view
2. Add a form to US3 that sends a start date and end date to controller
3. Add a submit button to that form.
4. If the end date is before the start date, controller will pass no data and return to view.
5. If data is input correctly, controller will send a IEnumerable of data back to the view of the expiditions within that timeframe.
6. The page will reload with a table of the information, unneeded data like login user will be removed.

## Dependencies
Nothing will depend on this user story being completed.

## Any notes written while implementing this story

Effort point of 1 because it is just finishing up a user story that was mostly done from last week that was not accepted.