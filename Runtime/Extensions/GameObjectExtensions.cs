using System;
using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// Extension methods for Unity GameObjects.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Sets the layer of the parent game object and all of its children.
        /// </summary>
        /// <param name="parent">The parent game object to set the layer of and its children.</param>
        /// <param name="layer">The layer to assign.</param>
        public static void SetLayerInChildren(this GameObject parent, int layer)
        {
            parent.layer = layer;

            foreach (Transform child in parent.transform) {
                SetLayerInChildren(child.gameObject, layer);
            }
        }

        /// <summary>
        /// Sets the layer of the parent game object and all of its children.
        /// </summary>
        /// <param name="parent">The parent game object to set the layer of and its children.</param>
        /// <param name="layer">The layer to assign.</param>
        public static void SetLayerInChildren(this GameObject parent, string layer)
        {
            SetLayerInChildren(parent, LayerMask.NameToLayer(layer));
        }

        /// <summary>
        /// Destroys all children game objects of the parent.
        /// </summary>
        /// <param name="parent">The parent game object to destroy the children of.</param>
        public static void DestroyChildren(this GameObject parent)
        {
            foreach (Transform child in parent.transform) {
                UnityEngine.Object.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Destroys all children game objects of the parent after a delay.
        /// </summary>
        /// <param name="parent">The parent game object to destroy the children of.</param>
        /// <param name="delay">The delay before destroying the game objects.</param>
        public static void DestroyChildren(this GameObject parent, float delay)
        {
            foreach (Transform child in parent.transform) {
                UnityEngine.Object.Destroy(child.gameObject, delay);
            }
        }

        /// <summary>
        /// Destroys all children game objects of the parent immediately. You
        /// are strongly recommended to use DestroyChildren instead.
        /// </summary>
        /// <param name="parent">The parent game object to destroy the children of.</param>
        /// <param name="allowDestroyingAssets">Allows project assets to be destroyed (default=false).</param>
        public static void DestroyChildrenImmediate(this GameObject parent, bool allowDestroyingAssets = false)
        {
            foreach (Transform child in parent.transform) {
                UnityEngine.Object.DestroyImmediate(child.gameObject, allowDestroyingAssets);
            }
        }

        /// <summary>
        /// Gets the specified component from the game object. If the component
        /// does not exist, then it will be added to the game object.
        /// </summary>
        /// <typeparam name="T">The type of component to get.</typeparam>
        /// <param name="gameObject">The game object to get the component from.</param>
        /// <returns>The component reference.</returns>
        public static T GetRequiredComponent<T>(this GameObject gameObject)
            where T : Component
        {
            if (gameObject.TryGetComponent(out T component)) {
                return component;
            } else {
                return gameObject.AddComponent<T>();
            }
        }

        /// <summary>
        /// Checks if the game object has a component of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of component to check for.</typeparam>
        /// <param name="gameObject">The game object to check for the component.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        public static bool HasComponent<T>(this GameObject gameObject)
            where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }

        /// <summary>
        /// Checks if the game object has a component of the specified type.
        /// </summary>
        /// <param name="gameObject">The game object to check for the component.</param>
        /// <param name="component">The type of component to check for.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        public static bool HasComponent(this GameObject gameObject, Type component)
        {
            return gameObject.GetComponent(component) != null;
        }

        /// <summary>
        /// Checks if the game object has a component of the specified type on
        /// itself or on any of its children using depth first search.
        /// </summary>
        /// <typeparam name="T">The type of component to check for.</typeparam>
        /// <param name="gameObject">The game object to check for the component.</param>
        /// <param name="includeInactive">Includes inactive game objects.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        public static bool HasComponentInChildren<T>(this GameObject gameObject, bool includeInactive = false)
            where T : Component
        {
            return gameObject.GetComponentInChildren<T>(includeInactive) != null;
        }

        /// <summary>
        /// Checks if the game object has a component of the specified type on
        /// itself or on any of its children using depth first search.
        /// </summary>
        /// <param name="gameObject">The game object to check for the component.</param>
        /// <param name="component">The type of component to check for.</param>
        /// <param name="includeInactive">Includes inactive game objects.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        public static bool HasComponentInChildren(this GameObject gameObject, Type component, bool includeInactive = false)
        {
            return gameObject.GetComponentInChildren(component, includeInactive) != null;
        }

        /// <summary>
        /// Checks if the game object has a component of the specified type on
        /// itself or any of its parents.
        /// </summary>
        /// <typeparam name="T">The type of component to check for.</typeparam>
        /// <param name="gameObject">The game object to check for the component.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        public static bool HasComponentInParent<T>(this GameObject gameObject)
            where T : Component
        {
            return gameObject.GetComponentInParent<T>() != null;
        }

        /// <summary>
        /// Checks if the game object has a component of the specified type on
        /// itself or any of its parents.
        /// </summary>
        /// <param name="gameObject">The game object to check for the component.</param>
        /// <param name="component">The type of component to check for.</param>
        /// <returns>True if the component exists, false otherwise.</returns>
        public static bool HasComponentInParent(this GameObject gameObject, Type component)
        {
            return gameObject.GetComponentInParent(component) != null;
        }

    }

}
