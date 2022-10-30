using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A reference to a value of the specified type, either a constant or a variable.
    /// </summary>
    /// <typeparam name="TValue">The type of value.</typeparam>
    /// <typeparam name="TVariable">The type of variable reference.</typeparam>
    [System.Serializable]
    public abstract class ValueReference<TValue, TVariable>
        where TVariable : ScriptableVariable<TValue>
    {
        /// <summary>
        /// Uses a constant value instead of a variable reference.
        /// </summary>
        [Tooltip("Uses a constant value instead of a variable reference.")]
        public bool useConstant = true;

        /// <summary>
        /// The constant value to use.
        /// </summary>
        [Tooltip("The constant value to use.")]
        public TValue constantValue;

        /// <summary>
        /// The variable to reference.
        /// </summary>
        [Tooltip("The variable to reference.")]
        public TVariable variable;

        /// <summary>
        /// The current value, either the constant value if set to use constant
        /// or the value of the variable reference.
        /// </summary>
        public TValue value
        {
            get
            {
                if (useConstant) {
                    return constantValue;
                } else if (variable != null) {
                    return variable.value;
                } else {
                    return default(TValue);
                }
            }
        }

        /// <summary>
        /// Creates a new double reference.
        /// </summary>
        public ValueReference() {}

        /// <summary>
        /// Creates a new double reference with the constant value.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        public ValueReference(TValue value)
        {
            this.useConstant = true;
            this.constantValue = value;
        }

        /// <summary>
        /// Creates a new double reference to the variable value.
        /// </summary>
        /// <param name="variable">The variable to reference.</param>
        public ValueReference(TVariable variable)
        {
            this.useConstant = false;
            this.variable = variable;
        }

    }

}
