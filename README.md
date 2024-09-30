# Hexa Vertical Slice

This is a sample application that demonstrates how to combine **Hexagonal Architecture** and **Vertical Slice Architecture**
in order to benefit from both worlds.

It is a simple WEB API in C# .NET.

It is composed of several bounded contexts, inspired by the LinkedIn domain.

Implemented patterns:
- Hexagonal architecture
- Vertical slice architecture
- CQRS in memory
- DDD tactical patterns

## Benefits from Hexagonal Architecture

- The core domain is isolated from technical details by exposing Port
- Infrastructure implements Adapter based on Port requirement

[More about it](https://en.wikipedia.org/wiki/Hexagonal_architecture_(software))

## Benefits from Vertical Slice Architecture

- Every use case contains a whole slice of the application
  - Use case
  - Business logics for dedicated business rules
  - Ports
  - Primary adapter (controller)
  - Secondary adapters (infrastructure)

- Shared infrastructure or business logic is centralized in the bounded context

[More about it](https://www.jimmybogard.com/vertical-slice-architecture/)

## Benefits from DDD tactical patterns

- The domain is modeled into bounded contexts in order to handle the its complexity
- Entities and value objects helps to model the business rules and invariants

[More about it](https://github.com/ddd-crew/ddd-starter-modelling-process?tab=readme-ov-file#tools-6)

## Criticism of this approach

### Advantages

✅ Business logic isolated from technical code

✅ What changes together is in the same place

✅ One project per bounded context

### Disavantages

❌ No physical separation: extremely easy to create a dependency between a business class and an infrastructure class

❌ Duplication of ports by use case: if two use cases need an “IPasswordHasher”, each will have its own port

## Bounded context introduction

### Networking : Core subdomain

This bounded context is responsible for invitations and connections between profiles.

Its aims is to provide a way to connect with other users.

### FeedComputation : Core subdomain

This bounded context is responsible for the feed computation.

Its aims is to compute a feed from profile connections and published posts.

### AccountManagement : Generic subdomain

This bounded context is responsible for user registration and login.

It handles the user accounts and the authentication.

