Feature: As an account holder, I want to be able to navigate between different months, so I can more easily mange events in different months.

Background:
		Given the user is logged in to any account
Scenario: A user can navigate to a previous month
		Given the user is on the display page
		When they click on the back arrow by the month name
		Then the display will change to show the month prior to the current month.

Scenario: A user can navigate to a future month
		Given the user is on the display page
		When they click on the forward arrow by the month name
		Then the display will change to show the month after to the current month.

Scenario: A user can continue navigating after changing the displayed month
		Given the user has already navigated to a different month using the arrows
		When they click on any arrow by the month name
		Then the display will change to show the desired month.