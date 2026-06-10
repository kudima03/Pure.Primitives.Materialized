# Pure.Primitives.Materialized

Eagerly evaluated **Pure** primitive wrappers — hold a concrete .NET value and expose it through the `Pure.Primitives.Abstractions` interfaces.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.Materialized/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Materialized/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.Materialized/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Materialized/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.Materialized)](https://www.nuget.org/packages/Pure.Primitives.Materialized)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Primitives.Materialized` provides `Materialized*` wrappers that hold a pre-computed .NET value and expose it through the corresponding `Pure.Primitives.Abstractions` interface. Unlike the lazy implementations in [`Pure.Primitives`](https://github.com/kudima03/Pure.Primitives), these types accept the already-evaluated primitive and return it directly — no computation on access.

These wrappers are useful when bridging from evaluated .NET values (e.g., query results, deserialized data) back into the Pure type system without wrapping in a lazy expression.

## Types

| Type | Implements | Holds |
|------|-----------|-------|
| `MaterializedBool` | `IBool` | `bool` |
| `MaterializedChar` | `IChar` | `char` |
| `MaterializedString` | `IString` | `string` |
| `MaterializedNumber<T>` | `INumber<T>` | `T` (a .NET numeric type) |
| `MaterializedGuid` | `IGuid` | `Guid` |
| `MaterializedDate` | `IDate` | `DateOnly` |
| `MaterializedTime` | `ITime` | `TimeOnly` |
| `MaterializedDateTime` | `IDateTime` | `DateTime` |
| `MaterializedDayOfWeek` | `IDayOfWeek` | `DayOfWeek` |

All types are `sealed record`s.

## Design Principles

- **Eagerly evaluated** — value is stored at construction time; no deferred computation.
- **Transparent** — each `Materialized*` type implements the same interface as its wrapped type.
- **AOT-compatible** — no reflection; fully compatible with Native AOT.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions) — Pure primitive interfaces
