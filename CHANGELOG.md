# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.0] - 2023/01/10

### Added

- Classes `PercentageVariable` and `PercentageReference`
  - Uses floats in the range [0..1]
  - Custom editor property drawer that uses a slider
- Functions `SetFixedValue` and `SetVariable` on `ValueReference`
- Virtual property `defaultValue` on `ScriptableVariable`
- Function `ResetToDefault` on `ScriptableVariable`
- Array and list extension method `IndexOf` to get the index of an element/item using a custom predicate

### Changed

- Renamed `TimerBehaviour` to `TimedBehaviour`
- Renamed `constantValue` to `fixedValue` in `ValueReference`
- Renamed `useConstant` to `useVariable` in `ValueReference`
  - Defaults to `false` instead of `true` to match the existing logic
- Renamed array and list extension method `IsAny` to `Contains`
- Renamed array and list extension method `IsEach` to `ContainsAll`
- Capitalized various property names
- Fixed documentation typos and grammar

## [1.0.0] - 2022/11/27

- Initial release
