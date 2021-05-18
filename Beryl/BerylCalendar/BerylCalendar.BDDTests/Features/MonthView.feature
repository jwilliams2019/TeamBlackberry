Feature: As an account holder, I want to see all events on a day of my choosing, so I can tell how busy my schedule is for the chosen day.

Background:
		Given the user is logged in to any account
		And that same user has saved events for the current day
Scenario: A user can see the month display
		Given the user is logged in
		When they are on the home page
		Then the user clicks on the "Home" button on the navbar

Scenario: A user will have events show up for a chosen day
		Given the user has created an event for the chosen day
		When the user clicks on a link in the month display
		Then the user will see the events for the selected day.

Scenario: A user will have an appropriate month display appear
		Given the user is logged in
		When the user enters a custom url for any date in day, month, year format
		Then the month view will format to match the date used for the page.