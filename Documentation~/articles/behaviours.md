---
slug: "/manual/behaviours"
---

# Behaviours

The **Architecture Toolkit** includes several behaviours that can be used across an application. All of the behaviours derive from `MonoBehaviour`.

<hr/>

### [CursorLockState](/api/Zigurous.Architecture/CursorLockState)

Sets the lock state of the cursor when the behaviour is enabled and disabled.

<hr/>

### [CursorVisibility](/api/Zigurous.Architecture/CursorVisibility)

Sets the visibility of the cursor when the behaviour is enabled and disabled.

<hr/>

### [LoadScene](/api/Zigurous.Architecture/LoadScene)

Loads a scene using a specified set of options.

<hr/>

### [Singleton\<T\>](/api/Zigurous.Architecture/Singleton-1)

Ensures only a single instance of a specified type is instantiated in the scene. The singleton will be destroyed when the scene is unloaded.

<hr/>

### [SingletonPersistent\<T\>](/api/Zigurous.Architecture/SingletonPersistent-1)

Ensures only a single instance of a specified type is instantiated in the scene. The singleton will not be destroyed when changing scenes, thus making it persistent.

<hr/>

### [TargetFrameRate](/api/Zigurous.Architecture/TargetFrameRate)

Sets the target frame rate of the application.

<hr/>

### [TimerBehaviour](/api/Zigurous.Architecture/TimerBehaviour)

Invokes timed events at a set interval and/or duration.

<hr/>

### [UpdateBehaviour](/api/Zigurous.Architecture/UpdateBehaviour)

An abstract class to derive from that can run in any update mode. The update mode can be changed as needed without occuring any additional performance cost.
