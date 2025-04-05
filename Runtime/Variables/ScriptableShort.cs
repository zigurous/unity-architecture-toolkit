using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A short value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Short", order = 10)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableShort")]
    public class ScriptableShort : ScriptableValue<short>
    {
        [SerializeField]
        [Delayed]
        private short m_Value;

        /// <inheritdoc/>
        public override short value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
