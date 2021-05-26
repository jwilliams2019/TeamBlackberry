Feature: As an admin, I want to be able to see all events if I so choose, so I can see what is on the server.

Background:
		Given the user is logged into an admin account
		And that the database has any saved events
Scenario: A user can into an admin account
		Given the user possesses administrative rights over the project
		When they enter correct credentials in the login page
		Then the user will sign into a seeded admin account.

Scenario: An admin can see every event in the database
		Given the admin is logged in
		When the admin enters the display
		Then the admin will be shown a list of all events currently entered in the database.

Scenario: An admin can delete any event in the database
		Given the admin is logged in
		When the admin enters the admin display
		And clicks on an event
		Then they will navigate to a page where they can update or delete the event.