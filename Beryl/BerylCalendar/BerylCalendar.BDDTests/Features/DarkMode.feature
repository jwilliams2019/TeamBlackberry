Feature: As an account holder, I want to be able to enable a dark mode for the website because my eyes are sensitive to bright lights.

Background:
		Given the user is logged into an account

Scenario: The user clicks the dark mode switch that is on the profile page, switching the site to dark mode
		When the user clicks the dark mode switch
		Then the sites css will be changed to a dark mode view, with a black background, instead of the original gray light mode.

Scenario: The user is in dark mode and the user clicks the dark mode button again to go back to light mode
		Given the the user is in dark mode
		When the user clicks the dark mode switch
		Then the sites css will be changed to a light mode view, with a grey background, instead of the black dark mode