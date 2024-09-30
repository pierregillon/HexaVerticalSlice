# HexaVerticalSlice

This is a sample application that demonstrates how to combine hexagonal architecture and vertical slice architecture
in order to benefit from both worlds.

## Implemented patterns

- Hexagonal architecture
- Vertical slice architecture
- CQRS in memory
- DDD tactical patterns

### Benefits from Hexagonal architecture

- The core domain is isolated from technical details
- It does not depend on the infrastructure

### Benefits from vertical slice architecture

- Every use case contains a whole slice of the application
  - Use case
  - Business logics for dedicated business rules
  - Ports
  - Primary adapter (controller)
  - Secondary adapters (infrastructure)

- Shared infrastructure or business logic is centralized in the bounded context

### Benefits from DDD tactical patterns

- The domain is split into bounded contexts in order to handle the complexity
- Entities and value objects helps to model the domain
- 
## Context

The project is a Web API.
It is composed of several bounded contexts, inspired by the LinkedIn domain.

## Bounded contexts

### Networking : Core domain

This bounded context is responsible for invitations and connections between profiles.
Its aims is to provide a way to connect with other users.

### FeedComputation : Core domain

This bounded context is responsible for the feed computation.
Its aims is to provide a way to compute a feed from profile connections and published posts.

### AccountManagement : Generic subdomain

This bounded context is responsible for user registration and login.
It handles the user account and the authentication.

