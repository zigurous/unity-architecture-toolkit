using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector2Int value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector2Int", order = 14)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableVector2Int")]
    public class ScriptableVector2Int : ScriptableValue<Vector2Int>
    {
        [SerializeField]
        [Delayed]
        private Vector2Int m_Value;

        /// <inheritdoc/>
        public override Vector2Int value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
