Feature: As an account holder, I want to color my events based on their type so I can easily tell what type an event is.

@mytag
Scenario: Opening the Sidebar
        Given I am logged in
        And I am on the Home page
        When I click on the Show Button
        Then a sidebar will appear on the right side of the calendar.

@mytag
Scenario: Closing the Sidebar
        Given I am logged in
        And I am on the Home page
        And the sidebar is displayed
        When I click on the Hide Button
        Then the sidebar on the right will disappear

@mytag
Scenario: Enabling type colors
        Given I am logged in
        And I am on the Home Page
        And the sidebar is open
        When I click Enable Colors
        Then the events on screen will change color based on types

@mytag
Scenario: Disabling type colors
        Given I am logged in
        And I am on the Home Page
        And the sidebar is open
        When I click Disable Colors
        Then the events on screen will change color back to white with a light grey border.
