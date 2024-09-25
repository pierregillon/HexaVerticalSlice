Feature: Get feed
In order to see valuable posts
As a user of the feed computation bc
I want to be able to get my current feed

Background:
    Given I am registered and logged in as user1@test.com

Scenario: By default, the feed is empty
    When I get my feed
    Then the feed is empty

#Scenario: A first level network post is visible in my feed
#    Given I requested user2@test.com to connect with me
#    And user2@test.com accepted my connection request
#    When use2@test.com write a post with title "My first post" and content "This is my first post"
#    Then my feed contains the following posts:
#        | Author | Date | Title         | Content               |
#        | user2  |      | My first post | This is my first post |