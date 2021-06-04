Feature: As an account holder, I want to be able to write in common language to create an event and start inputting a title so I don't have to start it in the page.

A connection to luis to be able to understand a command to start an event and possibly give it a title.

Background:
    Given I am user "User"
    And I am logged in
    And I am on the Display Page

@mytag
Scenario: Writing a Query
    Given I have clicked the "Feature" text box
    When I type on the keyboard
    Then what I type should show up in the same text box
    Examples:
        | Page    | Feature |
        | Display | Luis    |

@mytag
Scenario: Opening the CreateEvent page via Luis
    Given I have typed "EventQuery" in the Luis text box
    When I click the Interpret button
    Then the CreateEvent page will be opened with blank fields
    Examples:
        | EventQuery             |
        | Create a new Event     |
        | Schedule a new meeting |

@mytag 
Scenario: Opening the CreateEvent page with a Title field preset via Luis
    Given I have typed "TitleQuery" in the Luis text box
    And I have clicked the Interpret button
    And the "ResultPage" opens
    Then the Title field in the page will show "Title"
    Examples:
        | TitleQuery                                                  | ResultPage  | Title                 |
        | Create a new appointment called Doctor's appointment        | CreateEvent | Doctor's appointment  |
        | Create a new space in my calendar for Hangin' with the bros | CreateEvent | Hangin' with the bros |
