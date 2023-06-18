using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector2Int variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector2Int")]
    public class Vector2IntVariable : ScriptableVariable<Vector2Int>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private Vector2Int m_Value;

        /// <inheritdoc/>
        public override Vector2Int value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
