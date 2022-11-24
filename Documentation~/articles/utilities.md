---
slug: "/manual/utilities"
---

# Utilities

The **Architecture Toolkit** includes several utility classes that may be useful under specific situations.

<br/>

### [HashCode](/api/Zigurous.Architecture/HashCode)

Combines multiple hash codes into a single value.

```csharp
int hash2 = HashCode.Combine(a, b);
int hash3 = HashCode.Combine(a, b, c);
int hash4 = HashCode.Combine(a, b, c, d);
```

<hr/>

### [Identifier](/api/Zigurous.Architecture/Identifier)

Generates identifiers.

```csharp
string guid = Identifier.Guid(); // e.g. "0f8fad5b-d9cb-469f-a165-70867728950e"
string serialNumber = Identifier.SerialNumber(16); // e.g. "4935E22CD7854C15"
long id = Identifier.UnixTime();
```

<hr/>

### [IScriptableObjectResettable](/api/Zigurous.Architecture/IScriptableObjectResettable)

Resets scriptable objects back to their original values upon exiting play mode (Editor only). This is useful in situations where the values of a scriptable object are changed at runtime but you want to reset them the next time the game is played.

```csharp
public class Example : ScriptableObject, IScriptableObjectResettable
{
    public void ResetValues()
    {
        //...
    }
}
```

<hr/>

### [PathEscaper](/api/Zigurous.Architecture/PathEscaper)

Handles escaping and unescaping paths. This is useful in situations where certain characters are not valid such as for filenames.

```csharp
PathEscaper.Escape("https://unity.com/"); // https__003A__002F__002Funity__002Ecom__002F
PathEscaper.Unescape("https__003A__002F__002Funity__002Ecom__002F"); // https://unity.com/
```

<hr/>

### [Yield](/api/Zigurous.Architecture/Yield)

Caches yield statements to minimize garbage collection.

```csharp
private IEnumerator SomeCoroutine()
{
    //...

    yield return Yield.EndOfFrame;
    yield return Yield.FixedUpdate;
    yield return Yield.Wait(1f);
    yield return Yield.WaitRealtime(1f);

    //...
}
```
