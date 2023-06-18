---
slug: "/manual/attributes"
---

# Attributes

The **Architecture Toolkit** includes a few different C# attributes that are useful to customize the editor interface for custom data structures and behaviors without needing to write custom editor scripts.

<hr/>

### [[ConditionalShow]](/api/Zigurous.Architecture/ConditionalShowAttribute)

Shows the field in the editor based on the state of another field.

```csharp
// boolean condition
public bool useCustomValue;
[ConditionalShow(nameof(useCustomValue))]
public float customValue;
```
```csharp
// enum condition
public Axis axis;
[ConditionalShow(nameof(axis), (int)Axis.X)]
public float x;
[ConditionalShow(nameof(axis), (int)Axis.Y)]
public float y;
[ConditionalShow(nameof(axis), (int)Axis.Z)]
public float z;
```

<hr/>

### [[ConditionalHide]](/api/Zigurous.Architecture/ConditionalHideAttribute)

Hides the field in the editor based on the state of another field.

```csharp
// boolean condition
public bool useDefaultValue;
[ConditionalHide(nameof(useDefaultValue))]
public float customValue;
```
```csharp
// enum condition
public Option option;
[ConditionalHide(nameof(option), (int)Option.B)]
public float a;
[ConditionalHide(nameof(option), (int)Option.A)]
public float b;
```

<hr/>

### [[ReadOnly]](/api/Zigurous.Architecture/ReadOnlyAttribute)

Prevents the field from being modified in the editor.

```csharp
[ReadOnly]
public string info;
```

<hr/>

### [[Rename]](/api/Zigurous.Architecture/RenameAttribute)

Renames the field in the editor.

```csharp
[Rename("Custom Toggle")]
public bool toggle;
```
