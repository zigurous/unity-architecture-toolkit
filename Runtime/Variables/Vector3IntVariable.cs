using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector3Int variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector3Int")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/Vector3IntVariable")]
    public class Vector3IntVariable : ScriptableVariable<Vector3Int>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Vector3Int m_Value;

        /// <inheritdoc/>
        public override Vector3Int value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
