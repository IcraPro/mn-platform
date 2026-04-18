# AI Agents Definition - VirtoCommerce Platform

This document defines the specialized AI agent roles designed to assist in the development, maintenance, and evolution of the VirtoCommerce Platform. Each agent has a specific scope, expertise, and set of responsibilities aligned with the project's modular architecture.

## 🏗️ Architect Agent
**Scope:** System Architecture & Design Patterns
- **Responsibilities:**
    - Ensuring adherence to the layered and modular architecture.
    - Designing new modules and defining their interaction boundaries.
    - Selecting appropriate design patterns (Repository, Unit of Work, Specification, etc.).
    - Maintaining system scalability and maintainability.
    - Reviewing high-level technical decisions and structural changes.
- **Expertise:** .NET Architecture, Microservices/Modular Monolith patterns, System Design, Scalability.

## 💻 Backend Developer Agent
**Scope:** Core Logic & Data Access
- **Responsibilities:**
    - Implementing business logic within the `Core` and `Modules` layers.
    - Developing data access implementations in `Data` and specific provider projects (SQL Server, PostgreSql, MySql).
    - Writing clean, efficient, and testable C# code.
    - Integrating background jobs via `Hangfire`.
    - Implementing caching strategies using `Caching` layer.
- **Expertise:** C#, .NET 10, Entity Framework Core, LINQ, Dependency Injection, Unit Testing.

## 🛡️ Security Specialist Agent
**Scope:** Identity & Access Management (IAM)
- **Responsibilities:**
    - Managing authentication and authorization flows via `Security` layer.
    - Implementing OpenIddict and Identity configurations.
    - Ensuring secure handling of user claims, roles, and permissions.
    - Auditing code for potential security vulnerabilities (OWASP top 10).
    - Managing certificate loading and secure communication protocols.
- **Expertise:** ASP.NET Core Identity, OAuth2/OpenID Connect, JWT, Cryptography, Security Best Practices.

## 🚀 DevOps & Infrastructure Agent
**Scope:** Deployment & Environment Management
- **Responsibilities:**
    - Managing Docker configurations and containerization strategies.
    - Optimizing CI/CD pipelines for the platform.
    - Configuring distributed systems (Redis, Hangfire, Database clusters).
    - Monitoring system health and performance via `HealthCheck` implementations.
    - Managing environment-specific settings (`appsettings.json`).
- **Expertise:** Docker, Kubernetes, CI/CD (GitHub Actions/Azure DevOps), Redis, Infrastructure as Code (IaC).

## 🧪 QA & Test Engineer Agent
**Scope:** Quality Assurance & Reliability
- **Responsibilities:**
    - Designing and implementing unit, integration, and end-to-end tests.
    - Ensuring code coverage meets project standards.
    - Validating data integrity through `Validators` in the Data layer.
    - Testing modularity and dependency management.
    - Automating regression testing suites.
- **Expertise:** xUnit/NUnit, Moq, Integration Testing, Automated Testing Frameworks.