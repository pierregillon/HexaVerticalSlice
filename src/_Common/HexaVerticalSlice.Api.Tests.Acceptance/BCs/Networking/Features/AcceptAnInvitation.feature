Feature: Accept an invitation
In order to join the connections of a user and to add a user to my connections
As a user of the networking bc
I want to accept an invitation I have received

Background:
    Given I am registered and logged in as john@company.com
    And emma@company.com has registered

Scenario: By default, my invitations list is empty
    Then my invitations list is
      | Invited profile | Request date |

Scenario: An invitation to connect with another user is listed
    Given the current date is 2024-09-25
    When I invite emma@company.com to connect with
    Then my invitations list is
      | Invited profile  | Request date |
      | emma@company.com | 2024-09-25   |

Scenario: Once a request is accepted, the invitation is removed from the list
    Given I invited emma@company.com to connect with
    When emma@company.com accepts my invitation
    Then my invitations list is
      | User | Request date |