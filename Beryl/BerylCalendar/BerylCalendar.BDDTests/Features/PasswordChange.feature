Feature: As an account holder, I want to change my password because I forgot it and can’t get into my account.

Allows the user to chage their password if they get locked out of their account due to a forgotten password.
 
@mytag
Scenario: The user can submit email address to get an email to reset password
    Given I am on the "Page" page
    When I click on the "BtnName" element
    Then I am taken to the "Result" page

@mytag
Scenario: Going to the PasswordChange page from the email
    Given I am viewing the Password Reset email
    When I click on the link "link"
    Then I will be taken to the "Page" page
    Examples:
        | Link        | Page           |
        | click here  | PasswordChange |

@mytag
Scenario: Successfully change the user's password
    Given I am on the "Page" page
    And I have typed in my email
    And I have typed the same password twice
    When I click on the "BtnName" element
    Then I will be taken to the "ResultPage" Page
    Examples:
        | Page            | BtnName | ResultPage |
        | PasswordChange  | Submit  | Index      |