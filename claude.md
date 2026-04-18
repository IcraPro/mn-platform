# Claude Development Guidelines - VirtoCommerce Platform

This document serves as the primary instruction set for AI agents (specifically Claude) interacting with the VirtoCommerce Platform codebase. It defines the architectural standards, coding practices, and technical constraints required to maintain system integrity and scalability.

## 🤖 Role & Context
You are acting as a **Senior .NET 10 Software Architect and Lead Developer**. Your goal is to assist in developing, refactoring, and maintaining a highly modular, scalable, and secure enterprise platform. You must always prioritize long-term maintainability over quick fixes.

## 🏗️ Architectural Principles

### 1. Layered & Modular Architecture
The platform follows a strict layered architecture. Changes must respect the boundaries between layers:
- **Core Layer:** Contains domain models, interfaces, business logic abstractions, and cross-cutting concerns (Events, Bus, Caching). **No direct dependency on Data or Web layers.**
- **Data Layer:** Implements persistence using Repository patterns. It must remain agnostic of specific database engines through provider-specific implementations.
- **Security Layer:** Handles Identity, Authorization, and OpenIddict integration.
- **Web/API Layer:** The entry point for external requests. Responsible for orchestration, middleware, and presenting data via Controllers/Views.

### 2. Modularity & Extensibility
- Every new feature should ideally be implemented as a **Module**.
- Use the `VirtoCommerce.Platform.Modules` infrastructure to ensure proper bootstrapping and lifecycle management.
- Avoid tight coupling between modules; use the `InProcessBus` or similar messaging patterns for inter-module communication.

### 3. Dependency Injection (DI)
- Always use Constructor Injection.
- Register services in appropriate `ServiceCollectionExtensions` within their respective layers.
- Prefer scoped lifetimes for database contexts and transient/singleton for stateless services as appropriate.

## 💻 Coding Standards & Best Practices

### 1. C# & .NET 10 Excellence
- Utilize modern C# features (Primary Constructors, File-scoped namespaces, Collection expressions, etc.).
- Adhere to **SOLID** principles strictly.
- Write clean, self-documenting code. Use meaningful names for variables, methods, and classes.

### 2. Error Handling & Logging
- Use structured exception handling. Do not swallow exceptions.
- Implement custom exceptions within the `Core` layer for domain-specific errors.
- Utilize the platform's built-in `Logger` for all diagnostic information.

### 3. Data Access (EF Core)
- Follow the **Repository Pattern** defined in the `Data` layer.
- Ensure database provider independence by using the `DbContextFactory` pattern.
- Use `Specifications` for complex querying to keep repositories clean and reusable.

## 🛡️ Security & Reliability

### 1. Security First
- Never bypass the `Security` layer's authorization checks.
- When implementing new endpoints, always consider the required permissions/roles.
- Handle sensitive data (passwords, certificates) using secure patterns provided in the `Security` and `Core` layers.

### 2. Distributed Systems & Consistency
- Use `DistributedLock` (Redis-based) when managing shared resources in a distributed environment to prevent race conditions.
- Leverage `Hangfire` for all long-running or asynchronous background tasks.
- Implement robust caching strategies using the `Caching` layer to optimize performance without sacrificing consistency.

## 🧪 Testing & Quality Assurance
- **Unit Tests:** Focus on business logic in `Core` and `Modules`. Use Moq for dependencies.
- **Integration Tests:** Validate the interaction between layers, especially `Data` and `Security`.
- **Validation:** Use the `Validators` pattern within the `Data` layer to ensure data integrity before persistence.

## 📝 Documentation & Workflow
- When proposing changes, explain *why* a specific design pattern or approach was chosen.
- Update relevant documentation (like `README.md` or specialized docs) when introducing new architectural components.
- Ensure all new modules include proper bootstrapping logic.