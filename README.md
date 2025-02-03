# CQRS-Based Project

## Overview
This project implements the **Command Query Responsibility Segregation (CQRS)** design pattern to separate read and write operations, improving scalability and maintainability. The architecture ensures optimized data retrieval and efficient command execution.

## Technologies Used
- **.NET Core** - Backend framework
- **MediatR** - Mediator pattern for CQRS implementation
- **Entity Framework Core** - ORM for data access
- **FluentValidation** - Input validation

## Project Structure
The project follows a modular monolith approach with separate layers for commands, queries, and domain logic:

```
|-- Application
|   |-- Common
|   |-- Users
|   |   |-- Commands (Write Operations)
|   |   |   |-- Create
|   |   |   |-- Delete
|   |   |   |-- Update
|   |   |-- Models
|   |   |-- Queries (Read Operations)
|   |   |   |-- Read
|   |-- DependencyInjection.cs
|-- Domain
|   |-- Entities
|-- Infrastructure
|   |-- Services
|-- Persistence
|   |-- Configurations
|   |-- Migrations
|   |-- ApplicationDbContext.cs
|-- WebApi
|   |-- Properties
|   |-- Common
|   |-- Controllers
|   |   |-- ApiControllerBase.cs
|   |   |-- ...Controller.cs
|   |-- appsettings.json
```

## License
This project is licensed under the MIT License.
