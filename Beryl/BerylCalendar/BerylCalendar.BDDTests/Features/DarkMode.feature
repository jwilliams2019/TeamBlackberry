Feature: As an account holder, I want to be able to enable a dark mode for the website because my eyes are sensitive to bright lights.

Background:
		Given the user is logged into an account

Scenario: The user will be able to access their profile by clicking on their username
		Given the user is logged in
		When the user clicks their username in the top right of the screen, on the navbar
		Then the user will be sent to their profile

Scenario: The user clicks the dark mode switch that is on the profile page, switching the site to dark mode
		Given the the user is logged in and on the profile page
		When the user clicks the dark mode switch
		Then the sites css will be changed to a dark mode view, with a black background, instead of the original gray light mode.
		And when the user clicks the switch again, the css will be brought back to the original light mode.