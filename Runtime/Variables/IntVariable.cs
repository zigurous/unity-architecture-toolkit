using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An int variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Int")]
    public class IntVariable : ScriptableVariable<int>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private int m_Value;

        /// <inheritdoc/>
        public override int value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
