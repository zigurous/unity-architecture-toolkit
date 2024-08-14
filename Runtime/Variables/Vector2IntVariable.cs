using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector2Int variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector2Int", order = 14)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/Vector2IntVariable")]
    public class Vector2IntVariable : ScriptableVariable<Vector2Int>
    {
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
