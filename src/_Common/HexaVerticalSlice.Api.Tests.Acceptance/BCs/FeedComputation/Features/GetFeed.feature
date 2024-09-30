Feature: Get feed
In order to see valuable posts
As a user of the feed computation bc
I want to be able to get my current feed

Background:
    Given I am registered and logged in as john@company.com
    And I connected the following users
      | Email address    |
      | emma@company.com |

Scenario: By default, the feed is empty
    When I get my feed
    Then the feed is empty

Scenario: A first level network post is visible in my feed
    Given the current date is 2024-09-25
    When emma@company.com publishes a post with title "My first post" and content "This is my first post"
    And I get my feed
    Then my feed contains the following posts:
      | Author           | Date       | Title         | Content               |
      | emma@company.com | 2024-09-25 | My first post | This is my first post |

Scenario: Most recent posts are visible on top
    Given I connected the following users
      | Email address   |
      | sam@company.com |
    When emma@company.com publishes a post with title "My first post" and content "This is my first post"
    And sam@company.com publishes a post with title "New post" and content "This is a new post"
    And I get my feed
    Then my feed contains the following posts:
      | Author           | Title         | Content               |
      | sam@company.com  | New post      | This is a new post    |
      | emma@company.com | My first post | This is my first post |