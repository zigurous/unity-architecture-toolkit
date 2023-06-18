using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A variable type that derives from ScriptableObject.
    /// </summary>
    /// <typeparam name="T">The type of value.<typeparam>
    public abstract class ScriptableVariable<T> : ScriptableObject
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public abstract T value { get; set; }

        #if UNITY_EDITOR
        [Multiline]
        [SerializeField]
        [Tooltip("An optional description for the variable (Dev only).")]
        private string m_DeveloperDescription = "";
        #endif
    }

}
