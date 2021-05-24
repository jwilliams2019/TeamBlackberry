Feature: As an account holder, I want to be able to write in common language to create an event and start inputting a title so I don't have to start it in the page.

A connection to luis to be able to understand a command to start an event and possibly give it a title.

Background:
    Given I am user "User"
    And I am logged in


#Example:
#    | Page      | Feature | EventQuery               | Function | TitleQuery                                                    | Interpret   | NoneQuery                  | OopsMessage                                                                                          |
#    | "Display" | "Luis"  | "Create a new Event"     | "Luis"   | "Create a new appointment called Doctor's appointment"        | "Interpret" | "what's the weather like?" | "That is not a recognized command, please input a command to create an event with an optional title" |
#    | "Display" | "Luis"  | "Schedule a new meeting" | "Luis"   | "Create a new space in my calendar for Hangin' with the bros" | "Interpret" | "how old is my daughter?"  | "That is not a recognized command, please input a command to create an event with an optional title" |

@mytag
Scenario: Writing a Query
    Given I am on the "Page" page
    And I have clicked the "Feature" text box
    When I type on the keyboard
    Then what I type should show up in the same text box

@mytag
Scenario: Opening the CreateEvent page via luis
    Given I am on the "Page" page
    And I have typed "EventQuery" in the text box
    When I click the "Function" button
    Then the CreateEvent page will be opened with blank fields

@mytag 
Scenario: Opening the CreateEvent page with a Title field preset via luis
    Given I am on the "Page" page
    And I have typed "TitleQuery" in the text box
    And I have clicked the "Interpret" button
    And the "ResultPage" opens
    Then the Title field in the page will show "TitleQuery"

@mytag
Scenario: Luis does nothing
    Given I am on the "Page" page
    And I have typed "NoneQuery" in the text box
    And I have clicked the "Interpret" button
    Then a message saying "OopsMessage" will appear below the "Feature" text box