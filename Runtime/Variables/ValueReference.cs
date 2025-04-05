using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a value of the specified type, either a fixed value or a
    /// value saved in a ScriptableObject.
    /// </summary>
    /// <typeparam name="TFixedValue">The type of value.</typeparam>
    /// <typeparam name="TScriptableValue">The type of scriptable value.</typeparam>
    [System.Serializable]
    public abstract class ValueReference<TFixedValue, TScriptableValue>
        where TScriptableValue : ScriptableValue<TFixedValue>
    {
        /// <summary>
        /// Uses the value stored in the referenced ScriptableObject rather than
        /// a fixed value.
        /// </summary>
        [Tooltip("Uses the value stored in the referenced ScriptableObject rather than a fixed value.")]
        public bool useScriptableValue = false;

        /// <summary>
        /// The fixed value to use.
        /// </summary>
        [Tooltip("The fixed value to use.")]
        public TFixedValue fixedValue = default;

        /// <summary>
        /// The ScriptableObject that stores the value.
        /// </summary>
        [Tooltip("The ScriptableObject that stores the value.")]
        public TScriptableValue scriptableValue = null;

        /// <summary>
        /// The current value, either the fixed value or the value stored in the
        /// ScriptableObject.
        /// </summary>
        public TFixedValue value
        {
            get
            {
                if (!useScriptableValue) {
                    return fixedValue;
                } else if (scriptableValue != null) {
                    return scriptableValue.value;
                } else {
                    return default;
                }
            }
            set
            {
                if (useScriptableValue && scriptableValue != null) {
                    scriptableValue.value = value;
                } else {
                    SetFixedValue(value);
                }
            }
        }

        /// <summary>
        /// Creates a new reference to a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public ValueReference(TFixedValue value)
        {
            useScriptableValue = false;
            fixedValue = value;
            scriptableValue = null;
        }

        /// <summary>
        /// Creates a new reference to the value stored in a ScriptableObject.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public ValueReference(TScriptableValue value)
        {
            useScriptableValue = true;
            fixedValue = default;
            scriptableValue = value;
        }

        /// <summary>
        /// Switches to and assigns a fixed value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public void SetFixedValue(TFixedValue value)
        {
            useScriptableValue = false;
            fixedValue = value;
        }

        /// <summary>
        /// Switches to and assigns a reference to the ScriptableObject that
        /// stores the value.
        /// </summary>
        /// <param name="value">The ScriptableObject that stores the value.</param>
        public void SetScriptableValue(TScriptableValue value)
        {
            useScriptableValue = true;
            scriptableValue = value;
        }

    }

}
