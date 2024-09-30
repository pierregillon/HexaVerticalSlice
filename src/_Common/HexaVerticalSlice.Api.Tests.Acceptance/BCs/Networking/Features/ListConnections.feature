Feature: List connections
In order to find a specific contact
As a user of networking bc
I want to be able to list my connections

Background:
    Given I am registered and logged in as john@company.com
    And emma@company.com has registered

@ErrorHandling
Scenario: By default, I have no connections
    Then my connections are
      | User | Added date |

Scenario: Once a request is accepted, the user is added to my connections
    Given the current date is 2024-09-22
    When I invite emma@company.com to connect with
    And emma@company.com accepts my invitation
    Then my connections are
      | User          | Added date |
      | emma@test.com | 2024-09-22 |

Scenario: Once a request is accepted, I am added to the connections of the user
    Given the current date is 2024-09-22
    When I invite emma@company.com to connect with
    And emma@company.com accepts my invitation
    Then emma@company.com's connections are
      | User             | Added date |
      | john@company.com | 2024-09-22 |