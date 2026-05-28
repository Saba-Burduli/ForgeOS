# ADR 0001: Modular Monolith with CQRS and Domain Events

**Status**: Accepted  
**Date**: 2026-05-28

## Context
AI Startup OS requires rapid feature evolution across multiple bounded contexts while retaining strong domain boundaries, operational simplicity, and consistent observability. Early-stage traffic is expected to grow to 100,000+ founders with strict requirements for reliability, auditability, and clear module ownership.

## Decision
We will implement a **modular monolith** in ASP.NET Core with strict module isolation. Each module owns its domain, application, infrastructure, and contracts. Modules communicate via **contracts and integration events** only. Internal cross-module data access is prohibited.

We will apply **CQRS** with MediatR for command/query separation and use **domain events** to propagate internal state changes within module boundaries. Integration events will be published to RabbitMQ for cross-module workflows.

Each module will maintain its own EF Core `DbContext` and schema within a shared PostgreSQL instance. This preserves modular boundaries while avoiding the operational complexity of multiple databases in early stages.

Observability is first-class: OpenTelemetry tracing/metrics, structured logging, and health checks are built into the base platform.

## Consequences
- Clear module isolation simplifies reasoning, testing, and ownership boundaries.
- Cross-module workflows require explicit contracts/events, reducing accidental coupling.
- The modular monolith keeps deployment and operations simple while allowing future extraction of services.
- Some OpenTelemetry instrumentation packages are pre-release; this is tracked and will be upgraded to stable releases when available.
