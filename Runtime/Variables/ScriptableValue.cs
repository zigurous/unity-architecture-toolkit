using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A value type that derives from ScriptableObject.
    /// </summary>
    /// <typeparam name="T">The type of value.</typeparam>
    public abstract class ScriptableValue<T> : ScriptableObject
    {
        /// <summary>
        /// The stored value.
        /// </summary>
        public abstract T value { get; set; }

        /// <summary>
        /// The default value.
        /// </summary>
        public virtual T defaultValue => default;

        /// <summary>
        /// Resets the value to its default value.
        /// </summary>
        public void ResetToDefault()
        {
            value = defaultValue;
        }

    }

}
