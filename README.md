# BackendChallenge+

## Getting Started

### Tecnologies

- .NET 7
- Serilog
- Docker

### Setup

1. Clone repo
2. Go to root, and build the Docker image

```
docker build -t backend_challenge:dev -f Dockerfile .
```

3. Run image

```
docker run -dp 5001:80 --name backend_challenge_api backend_challenge:dev
```

## Arquitecture

### Clean Architecture

In Clean Architecture, an application is divided into responsibilities and each of these responsibilities is represented as a layer.

It is based on the fact that the domain layer does not depend on any outer layer. The application layer only depends on the domain layer and the rest (usually presentation and data access) depends on the application layer. This is achieved with the implementation of service interfaces that will then have to be implemented by the external layers and with dependency injection.

### Layers

- Domain: it is the heart of the application and it has to be completely isolated from any dependency foreign to business logic or data. It can contain entities, value objects, events and domain services.
- Application: it is the layer that contains the services that connect the domain with the outside world (outer layers). Here contracts, interfaces are defined.
- Infrastructure: is the data access layer. It implements interfaces defined in the Application layer.
- API: is the presentation layer. It handles requests and responses, and commonly communicates with the Application layer.

### Patterns and methodologies used:

- _MediatR_: For calling services to the application layer without making use of dependencies.
  Not only to avoid the issue of dependencies, but above all to structure the query calls (query) and commands (insertion/modification/deletion) in an easily understandable, developable and maintainable way.

- _CQRS_: Architecture pattern that separates models for reading and writing data.
  The basic idea is that you can divide the operations of a system into two clearly differentiated categories:

  _Consultas_. These queries return a result without changing the state of the system and have no side effects..

  _Comandos_. These commands change the state of a system.

- FluentValidation. It allows "isolating" the validations of the commands to have them in a single place and thus save code.
