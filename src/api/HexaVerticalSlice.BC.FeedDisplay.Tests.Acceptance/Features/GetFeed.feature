Feature: Get feed
In order to see valuable posts
As a user of the feed display
I want to be able to get my current feed

Scenario: By default, the feed is empty
    When I get my feed
    Then the feed is empty