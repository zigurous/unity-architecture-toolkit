using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A variable type that derives from ScriptableObject.
    /// </summary>
    /// <typeparam name="T">The type of value.</typeparam>
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public abstract T value { get; set; }

        /// <summary>
        /// The default value of the variable.
        /// </summary>
        public virtual T defaultValue => default;

        #if UNITY_EDITOR
        #pragma warning disable 0414
        [Multiline]
        [SerializeField]
        [Tooltip("An optional description for the variable (Dev only).")]
        private string m_DeveloperDescription = "";
        #pragma warning restore 0414
        #endif

        /// <summary>
        /// Resets the value to its default value.
        /// </summary>
        public void ResetToDefault()
        {
            value = defaultValue;
        }

    }

}
