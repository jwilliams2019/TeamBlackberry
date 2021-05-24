Feature: As an account holder, I want days with events to be highlighted within the month view, so I can easily tell which days have something planned.

Background:
		Given the user is logged in to any account
		And that same user has saved events
Scenario: A user can see highlighted days within the month display
		Given the user is on the display page
		When they navigate to a month
		Then the user will see days within that month highlighted if they contain events.

Scenario: A user can change the highlighted days within the month display
		Given the user creates or deletes an event
		When the user navigates to the display page
		Then the user will see the month display update to include their additions/deletions.