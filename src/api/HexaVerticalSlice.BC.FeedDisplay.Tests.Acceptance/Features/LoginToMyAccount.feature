Feature: Login to my account

As a user
I want to login to my account
In order to use the app

Background:
    Given the current date is 2024-07-12

@ErrorHandling
Scenario: Cannot log in with invalid email
    When I log in with
      | Field         | Value           |
      | Email address | <Invalid email> |
      | Password      | P@ssword!       |
    Then a bad request error occurred with type BadEmailAddressFormat and message "The provided email has a bad format."
Examples:
  | Invalid email |
  | test          |
  | test@         |
  | test@company  |

@ErrorHandling
Scenario: Cannot log in with unknown user
    When I log in with
      | Field         | Value            |
      | Email address | unknown@test.com |
      | Password      | P@ssword!        |
    Then an unauthorized error occurred with type LoginFailed and message "Incorrect user or password"

@ErrorHandling
Scenario: Cannot log in with invalid password
    Given I am registered with
      | Field         | Value                  |
      | Email address | john.doe@mycompany.com |
      | Password      | P@ssw0rd!              |
    When I log in with
      | Field         | Value                  |
      | Email address | john.doe@mycompany.com |
      | Password      | P@ssword!!!!!          |
    Then an unauthorized error occurred with type LoginFailed and message "Incorrect user or password"

Scenario: Log in to my account allows me to use the app for 90 days
    Given I am registered with
      | Field         | Value                  |
      | Email address | john.doe@mycompany.com |
      | Password      | P@ssw0rd!              |
     When I log in with
       | Field         | Value                  |
       | Email address | john.doe@mycompany.com |
       | Password      | P@ssw0rd!              |
    Then I can now use the app until the 2024-10-10