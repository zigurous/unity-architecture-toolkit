using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Vector3Int value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Vector3Int", order = 16)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableVector3Int")]
    public class ScriptableVector3Int : ScriptableValue<Vector3Int>
    {
        [SerializeField]
        [Delayed]
        private Vector3Int m_Value;

        /// <inheritdoc/>
        public override Vector3Int value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
