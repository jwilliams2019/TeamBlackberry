Feature: As an account holder, I want to be able search for specific events by location so I can adjust my schedule to save time.

Background:
		Given the user is logged into an account
		And that the user has multiple events scheduled for the same day
		And that the main display only shows events for the current day

Scenario: The user will not be able to access the day/month display without being logged in
		Given the user is not logged in
		When the user tries to go to the day/month view
		Then the user will be sent to the login page instead

Scenario: The user enters part or all of a location into the search bar and presses "Search"
		Given the logged in user is on the day/month page
		When the user types in part of all of a location for an event that is on that day
		Then the user will be shown all events that have a location matching the text that was submitted