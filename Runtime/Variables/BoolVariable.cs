using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A boolean variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Bool")]
    public class BoolVariable : ScriptableVariable<bool>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private bool m_Value;

        /// <inheritdoc/>
        public override bool value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
