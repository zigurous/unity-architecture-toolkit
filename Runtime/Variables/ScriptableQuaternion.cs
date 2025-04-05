using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A Quaternion value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Quaternion", order = 8)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableQuaternion")]
    public class ScriptableQuaternion : ScriptableValue<Quaternion>
    {
        [SerializeField]
        [Delayed]
        private Quaternion m_Value;

        /// <inheritdoc/>
        public override Quaternion value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
