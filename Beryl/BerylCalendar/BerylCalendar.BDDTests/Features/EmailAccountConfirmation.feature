Feature: As an account holder, I want to be able search for specific events by location so I can adjust my schedule to save gas.

Background:
		Given the user is not logged into an account
		And that the account name or email the user wants to sign up with is not in use

Scenario: The user will be brought to a page stating they need to verify their account through email
		Given the user has successfully created an account
		When the user is brought to the next page
		Then the user will be notified that they have been sent an email to confirm their account.

Scenario: The user will not be able to go to any of the calendar displays without being a verified account
		Given the user is not successfully logged in
		When the user tries to reach either the week or calendar view
		Then the user will instead be brought back to the login page

Scenario: The user clicks the link given to them in the email and confirms their account
		Given the user recieves a confirmation email when they created their account
		When the user clicks the link that was emailed to them
		Then the user will be brought to a new place informing them that their account has been confirmed and that they can log in