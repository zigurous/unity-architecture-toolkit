---
slug: "/manual/data-structures"
---

# Data Structures

The **Architecture Toolkit** contains various data structures that may be useful throughout a project. All of the following data structures are available in the package:

## Accumulators

Accumulators work like a reducer function by accumulating a set of values into a single total value except you can store the values using identifiers. This is useful to accumulate values over time while adding and removing values as needed. The total value is updated automatically any time a value is added or removed.

Supported types:

- [Double](/api/Zigurous.Architecture/DoubleAccumulator)
- [Float](/api/Zigurous.Architecture/FloatAccumulator)
- [Int](/api/Zigurous.Architecture/IntAccumulator)
- [Quaternion](/api/Zigurous.Architecture/QuaternionAccumulator)
- [Vector2](/api/Zigurous.Architecture/Vector2Accumulator)
- [Vector2Int](/api/Zigurous.Architecture/Vector2IntAccumulator)
- [Vector3](/api/Zigurous.Architecture/Vector3Accumulator)
- [Vector3Int](/api/Zigurous.Architecture/Vector3IntAccumulator)
- [Vector4](/api/Zigurous.Architecture/Vector4Accumulator)

## Ranges

Ranges allow you to specify a lower and upper bound which can then be used for a multitude of purposes including clamping values, interpolating numbers, generating random values, and more.

Included types:

- [Range\<T\>](/api/Zigurous.Architecture/Range-1)
- [ClampedRange](/api/Zigurous.Architecture/ClampedRange)
- [ColorRange](/api/Zigurous.Architecture/ColorRange)
- [DoubleRange](/api/Zigurous.Architecture/DoubleRange)
- [EulerRange](/api/Zigurous.Architecture/EulerRange)
- [FloatRange](/api/Zigurous.Architecture/FloatRange)
- [IntRange](/api/Zigurous.Architecture/IntRange)
- [UIntRange](/api/Zigurous.Architecture/UIntRange)
- [UnitIntervalRange](/api/Zigurous.Architecture/UnitIntervalRange)
- [Vector2Range](/api/Zigurous.Architecture/Vector2Range)
- [Vector2IntRange](/api/Zigurous.Architecture/Vector2IntRange)
- [Vector3Range](/api/Zigurous.Architecture/Vector3Range)
- [Vector3IntRange](/api/Zigurous.Architecture/Vector3IntRange)
- [Vector4Range](/api/Zigurous.Architecture/Vector4Range)

## Misc

- [Bitmask](/api/Zigurous.Architecture/Bitmask) - A bitmask representation that can be used for bitwise operations.
- [Bool3](/api/Zigurous.Architecture/Bool3) - Stores a tuple of 3 booleans
- [GridSize](/api/Zigurous.Architecture/GridSize) - Stores the size of a grid as rows and columns.
- [Quantity\<T\>](/api/Zigurous.Architecture/Quantity-1) - Stores a quantity of a given entity type
- [Registry\<T\>](/api/Zigurous.Architecture/RegisteredList-1) - Manages a list of unique items and invokes callbacks when an item is added or removed from the list.
- [RuntimeSet\<T\>](/api/Zigurous.Architecture/RuntimeSet-1) - A ScriptableObject that stores a list of items. A project asset can be created for the runtime set so it can be referenced throughout the application, but the items are added and removed at runtime.
- [Size](/api/Zigurous.Architecture/Size) - Stores the size of an entity as a width and height
