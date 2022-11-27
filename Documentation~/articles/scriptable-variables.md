---
slug: "/manual/scriptable-variables"
---

# Scriptable Variables

The **Architecture Toolkit** defines [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) variables for all primitive types and common Unity structs like vectors. Saving a variable as a ScriptableObject allows that variable to be referenced by different systems without having to deal with object dependencies.

All of these variables can be created through the Asset menu, `Zigurous > Variables > ...`. Custom variable types can be created as needed. They all derive from [ScriptableVariable\<T\>](/api/Zigurous.Architecture/ScriptableVariable-1) which derives from [ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html).

For example, the player can declare their hitpoints as a `FloatVariable` instead of a `float`. A health bar script would also declare a hitpoints property as a `FloatVariable`. Both behaviours could reference the same variable asset without needing any dependencies between them.

The downside with this is it can be cumbersome to create assets for every variable declared in a behaviour. Instead of declaring `FloatVariable` we can declare a `FloatReference` for additional flexibility. This allows the value to either be a constant value or a reference to a variable asset; the choice is customizable in the editor. These reference types derive from [ValueReference\<TValue, TVariable\>](/api/Zigurous.Architecture/ValueReference-2).

### Supported Types

- Bool
- Bounds
- Double
- Float
- Int
- Long
- Quaternion
- Rect
- Short
- String
- UInt
- Vector2
- Vector2Int
- Vector3
- Vector3Int
- Vector4
