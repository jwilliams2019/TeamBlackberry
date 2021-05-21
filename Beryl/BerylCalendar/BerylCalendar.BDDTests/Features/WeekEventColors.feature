Feature: As an account holder, I want the events in the week view to show a specific color for each type of event so that I can quickly tell at a glance which type of event one is.

Background:
		Given the user is logged into an account
		And the user has at least one event for the current week

Scenario: The user will be able to go to the week view and see all events in the current week when clicking on the "Week" button in the navbar
		Given the user is logged in
		When the user clicks the "Week" button on the navbar
		Then the user will be sent to the week view and be shown all of their events for the current week

Scenario: All of the events will be color coded
		Given the user has an event in the current week
		When the user loads the week view
		Then the events will be color-coded to their correct color. Activity = red, meal = yellow, shopping = blue, visit = green
