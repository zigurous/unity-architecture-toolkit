using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector3 variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector3")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/Vector3Variable")]
    public class Vector3Variable : ScriptableVariable<Vector3>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Vector3 m_Value;

        /// <inheritdoc/>
        public override Vector3 value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
