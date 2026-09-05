# Changelog

All notable changes to Pure.Primitives.Materialized are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0] — 2025-06-11

### Added

Initial release. Eagerly evaluated `Materialized*` wrappers that hold a
pre-computed .NET value and expose it through the corresponding
`Pure.Primitives.Abstractions` interface, with no deferred computation:

- **`MaterializedBool`** — implements `IBool`, holds a `bool`.
- **`MaterializedChar`** — implements `IChar`, holds a `char`.
- **`MaterializedString`** — implements `IString`, holds a `string`.
- **`MaterializedNumber<T>`** — implements `INumber<T>` for any
  `System.Numerics.INumber<T>`, holds a `T`.
- **`MaterializedGuid`** — implements `IGuid`, holds a `Guid`.
- **`MaterializedDate`** — implements `IDate`, holds a `DateOnly`.
- **`MaterializedTime`** — implements `ITime`, holds a `TimeOnly`.
- **`MaterializedDateTime`** — implements `IDateTime`, holds a `DateTime`.
- **`MaterializedDayOfWeek`** — implements `IDayOfWeek`, holds a `DayOfWeek`.

All types are `sealed record`s targeting `net8.0`, `net9.0`, and `net10.0`,
and are AOT-compatible.
