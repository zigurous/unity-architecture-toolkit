using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a value of the specified type, either a fixed value or a variable.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <typeparam name="TVariable">The type of variable reference.</typeparam>
    [System.Serializable]
    public abstract class ValueReference<TValue, TVariable>
        where TVariable : ScriptableVariable<TValue>
    {
        /// <summary>
        /// Uses a variable reference instead of a fixed value.
        /// </summary>
        [Tooltip("Uses a variable reference instead of a fixed value.")]
        public bool useVariable = false;

        /// <summary>
        /// The variable to reference.
        /// </summary>
        [Tooltip("The variable to reference.")]
        public TVariable variable = null;

        /// <summary>
        /// The fixed value to use.
        /// </summary>
        [Tooltip("The fixed value to use.")]
        public TValue fixedValue = default;

        /// <summary>
        /// The current value, either the fixed value or the value of the
        /// referenced variable.
        /// </summary>
        public TValue value
        {
            get
            {
                if (!useVariable) {
                    return fixedValue;
                } else if (variable != null) {
                    return variable.value;
                } else {
                    return default;
                }
            }
            set
            {
                SetFixedValue(value);
            }
        }

        /// <summary>
        /// Creates a new value reference.
        /// </summary>
        public ValueReference() {}

        /// <summary>
        /// Creates a new value reference with the fixed value.
        /// </summary>
        /// <param name="value">The fixed value to set.</param>
        public ValueReference(TValue value)
        {
            useVariable = false;
            fixedValue = value;
            variable = null;
        }

        /// <summary>
        /// Creates a new value reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public ValueReference(TVariable variable)
        {
            useVariable = true;
            fixedValue = default;
            this.variable = variable;
        }

        /// <summary>
        /// Switches to use a fixed value and assigns the provided value.
        /// </summary>
        /// <param name="value">The fixed value to use.</param>
        public void SetFixedValue(TValue value)
        {
            useVariable = false;
            fixedValue = value;
        }

        /// <summary>
        /// Switches to use a variable reference and assigns the provided variable.
        /// </summary>
        /// <param name="variable">The variable reference to use.</param>
        public void SetVariable(TVariable variable)
        {
            useVariable = true;
            this.variable = variable;
        }

    }

}
