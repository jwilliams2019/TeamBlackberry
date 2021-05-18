Feature: As an account holder, I want days with events to be highlighted within the month view, so I can easily tell which days have something planned.

Background:
		Given the user is logged in to any account
		And that same user has saved events
Scenario: A user can see highlighted days within the month display
		Given the user is logged in
		When they are on the display page
		Then the user will see days within the month view highlighted if they contain events.

Scenario: A user can change the highlighted days within the month display
		Given the user is logged in
		When the user creates or deletes an event
		And navigates to the display page
		Then the user will see the month display update to include their additions/deletions.