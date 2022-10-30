using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Quaternion variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Quaternion")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/QuaternionVariable")]
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
