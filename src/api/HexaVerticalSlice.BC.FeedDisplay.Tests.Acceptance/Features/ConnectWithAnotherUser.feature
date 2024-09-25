Feature: Connect with another user
In order to extend my network, share my posts and see others posts
As a user of the feed display
I want to be able to connect with other users

Background:
    Given I am registered and logged in as john@company.com
    And emma@company.com has registered

@ErrorHandling
Scenario: Cannot connect with an unknown user
    When I request to connect with an unknown user
    Then an not found error occurred

Scenario: By default, my invitations list is empty
    Then my invitations list is
      | Invited profile | Request date |

Scenario: A request to connect with another user is listed
    Given the current date is 2024-09-25
    When I request to connect with emma@company.com
    Then my invitations list is
      | Invited profile  | Request date |
      | emma@company.com | 2024-09-25   |

Scenario: Once a request is accepted, the invitation is removed from the list
    Given I requested to connect with user2@test.com
    When emma@company.com accepts my invitation
    Then my invitations list is
      | User | Added date |

Scenario: Once a request is accepted, the user is added in my network
    Given the current date is 2024-09-22
    When I request to connect with user2@test.com
    And emma@company.com accepts my invitation
    Then my connections are
      | User          | Added date |
      | emma@test.com | 2024-09-22 |