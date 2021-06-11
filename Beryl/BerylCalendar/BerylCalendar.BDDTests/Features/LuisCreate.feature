Feature: As an account holder, I want to be able to write in common language to create an event and start inputting a title so I don't have to start it in the page.

A connection to luis to be able to understand a command to start an event and possibly give it a title.

Background:
    Given I am logged in as a user
      And I am on the Display Page

@mytag
Scenario: Writing a Query
    Given I have clicked the "Feature" text box
    When I type "Phrase" on the keyboard
    Then "ResultPhrase" shows up in the text box
    Examples:
        | Feature | Phrase | ResultPhrase |
        | Luis    | Hello  | Hello        |

@mytag
Scenario: Opening the CreateEvent page via Luis
    Given I have typed "Query" in the Luis text box
    When I click the Interpret button
    Then the CreateEvent page will be opened with default values
    Examples:
        | Query                  |
        | Create a new Event     |
        | Schedule a new meeting |

@mytag 
Scenario: Opening the CreateEvent page with a Title field preset via Luis
    Given I have typed "Query" in the Luis text box
    When I click the Interpret button
    Then the CreateEvent page will be opened with the Title being "Title"
    Examples:
        | Query                                                       | Title                 |
        | Create a new appointment called Doctor's appointment        | Doctor's appointment  |
        | Create a new space in my calendar for Hangin' with the bros | Hangin' with the bros |
