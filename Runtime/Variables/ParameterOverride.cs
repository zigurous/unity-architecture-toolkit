using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A generic type to override parameter values.
    /// </summary>
    /// <typeparam name="T">The type of parameter value.</typeparam>
    [System.Serializable]
    public class ParameterOverride<T> : ParameterOverride
    {
        /// <summary>
        /// The overridden parameter value.
        /// </summary>
        [Tooltip("The overridden parameter value.")]
        public T value;

        /// <summary>
        /// Implicitly converts a value to a parameter override.
        /// </summary>
        /// <typeparam name="T">The type of parameter value.</typeparam>
        /// <param name="parameter">The value to convert.</param>
        /// <returns>The parameter override with the value set.</returns>
        public static implicit operator ParameterOverride<T>(T parameter)
        {
            return new() {
                value = parameter,
                overrideState = false,
            };
        }

    }

    /// <summary>
    /// The base class for overriding parameter values.
    /// </summary>
    public abstract class ParameterOverride
    {
        /// <summary>
        /// Whether the parameter value is overridden.
        /// </summary>
        [Tooltip("Whether the parameter value is overridden.")]
        public bool overrideState;
    }

}
