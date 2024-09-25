Feature: Consult a profile
In order to consult a profile
As a user of networking bc
I want profiles to be created after user has registered

Background:
    Given I am registered and logged in as john@company.com

@ErrorHandling
Scenario: Cannot consult an unknown profile
    When I search for unknown@company.com profile
    Then a not found error occurred

Scenario: I can consult profile of registered user
    Given eric@company.com has registered
    When I search for eric@company.com profile
    Then the profile details are
      | Field         | Value            |
      | Email address | eric@company.com |

Scenario: I can consult my own profile
    When I search for john@company.com profile
    Then the profile details are
      | Field         | Value            |
      | Email address | john@company.com |