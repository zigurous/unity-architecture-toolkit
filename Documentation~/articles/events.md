---
slug: "/manual/events"
---

# Events

Events are powerful tool provided by Unity. The **Architecture Toolkit** extends this system by allowing events to be saved as ScriptableObjects. This means the same event can be referenced and listened to by multiple systems throughout the project.

<hr/>

## 📅 Game Event

An event can be created through the Asset menu, `Zigurous > Events > Game Event`. There are no properties on an event, but they can be extended further with subclasses if needed. See the [GameEvent](/api/Zigurous.Architecture/GameEvent) Scripting API.

<hr/>

## 🎧 Game Event Listener

A [GameEventListener](/api/Zigurous.Architecture/GameEventListener) component can be added to any game object that needs to listen for an event. This is a class that derives from `MonoBehaviour` and will register and unregister itself as a listener for the specified event. The listener also declares a standard `UnityEvent` response property that is invoked when the event is raised.

<hr/>

## 🎫 Event Reference

The [EventReference](/api/Zigurous.Architecture/EventReference) class allows a `UnityEvent` or `GameEvent` to be referenced. The option to switch between the two choices is available in the editor. Anywhere you might declare a variable as a `UnityEvent` or a `GameEvent` consider declaring it as an `EventReference` for more flexibility.
