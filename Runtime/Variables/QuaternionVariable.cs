using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Quaternion variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Quaternion")]
    public class QuaternionVariable : ScriptableVariable<Quaternion>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Quaternion m_Value;

        /// <inheritdoc/>
        public override Quaternion value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
