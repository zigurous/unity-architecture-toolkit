using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector2 value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector2", order = 13)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableVector2")]
    public class ScriptableVector2 : ScriptableValue<Vector2>
    {
        [SerializeField]
        [Delayed]
        private Vector2 m_Value;

        /// <inheritdoc/>
        public override Vector2 value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
