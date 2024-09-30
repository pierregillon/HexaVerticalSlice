Feature: Comment a post
In order to give my option on a post
As a user of the feed computation bc
I want to comment a post

Background:
    Given I am registered and logged in as john@company.com
    And I connected the following users
      | Email address    |
      | emma@company.com |

Scenario: By default, a post has no thread
    Given a post with title "My first post" and content "This is my first post" has been published
    When I get the "My first post" post details
    Then the post has the following threads:
      | Author | Comment | Date |

Scenario: Commenting a post creates a thread
    Given the current date is 2024-09-30
    And a post with title "My first post" and content "This is my first post" has been published
    When I publish a comment "Nice post" on the "My first post" post
    And I get the "My first post" post details
    Then the post has the following threads:
      | Author           | Comment   | Date       |
      | john@company.com | Nice post | 2024-09-30 |