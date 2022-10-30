using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A string variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/String")]
    public class StringVariable : ScriptableVariable<string>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private string m_Value;

        /// <inheritdoc/>
        public override string value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
