using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector4 variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector4")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/Vector4Variable")]
    public class Vector4Variable : ScriptableVariable<Vector4>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Vector4 m_Value;

        /// <inheritdoc/>
        public override Vector4 value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
