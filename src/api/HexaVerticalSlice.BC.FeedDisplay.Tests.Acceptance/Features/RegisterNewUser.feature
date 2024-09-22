Feature: Register a new user

As a user
I want to register
In order to use the app

Background:
    Given the current date is 2022-10-23

@ErrorHandling
Scenario: Cannot register a user with an invalid email
    When I register with email "<Invalid email>"
    Then a bad request error occurred with type BadEmailAddressFormat and message "The provided email has a bad format."

Examples:
  | Invalid email |
  | test          |
  | test@         |
  | test@company  |

@ErrorHandling
Scenario: Cannot register a user with a weak password
    When I register with password "<Weak password>"
    Then a bad request error occurred with type TooWeakPassword and message "The provided password is too weak."

Examples:
  | Weak password |
  | te!           |
  | aaa           |
  | ...           |
  | d             |

Scenario: Registering a user allows me to use the app for 90 days
    Given the token validity is 90 days
    When I register and log in with
      | Field         | Value                  |
      | Email address | john.doe@mycompany.com |
      | Password      | P@ssw0rd!              |
    Then I can now use the app until the 2023-01-21

Scenario: After registered, I can log in
    Given I am registered with
      | Field         | Value                  |
      | Email address | john.doe@mycompany.com |
      | Password      | P@ssw0rd!              |
     When I log in with
       | Field         | Value                  |
       | Email address | john.doe@mycompany.com |
       | Password      | P@ssw0rd!              |
    Then I can now use the app until the 2023-01-21