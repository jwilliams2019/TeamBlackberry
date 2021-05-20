Feature: As an account holder, I want to display all of my events in a week so I can see how busy this week will be.
<img src="https://images.twinkl.co.uk/tw1n/image/private/t_630/image_repo/39/90/us-t-l-4077-days-of-the-week-flashcards-english-united-states_ver_1.jpg" width=150 />

Background:
		Given the user is logged in to any account
		And that same user has saved events for the current week, starting from sunday

Scenario: A user will be sent to the login page if they try to get into the week view while not logged in
		Given the user is not currently logged in
		When the user tries to go to the week view
		Then the user will be sent to the login page instead

Scenario: A user can see the week view
		Given the user is logged in
		When they are on the home page
		Then the user clicks on the "Week" button on the navbar

Scenario: A user will have events show up under the day of the week
		Given the user has created an event under a day of the current week
		When the user clicks the "Week" button on the navbar
		Then the user will see that event under the the day the event starts.