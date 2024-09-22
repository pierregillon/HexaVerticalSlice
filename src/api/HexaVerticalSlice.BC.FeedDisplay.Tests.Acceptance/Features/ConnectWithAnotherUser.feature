Feature: Connect with another user
In order to extend my network, share my posts and see others posts
As a user of the feed display
I want to be able to connect with other users

Background:
    Given I am registered and logged as user1@test.com
    
Scenario: A request to connect with another user is listed in invitations
    When I request to connect with user2@test.com
    Then the invitations list is
        | User | Request date |
        | user2@test.com | Today |
        
Scenario: Once a request is accepted, the invitation is removed from the list
    Given I requested to connect with user2@test.com
    When the user user2@test.com accepts my invitation
    Then the invitations list is
    | User | Added date |
        
Scenario: Once a request is accepted, the user is added in my network
    When I request to connect with user2@test.com
    And the user user2@test.com accepts my invitation
    Then my network is
    | User | Added date |
    | user2@test.com | Today |
 