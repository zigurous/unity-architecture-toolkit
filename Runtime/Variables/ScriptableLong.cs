using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A long value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Long", order = 6)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableLong")]
    public class ScriptableLong : ScriptableValue<long>
    {
        [SerializeField]
        [Delayed]
        private long m_Value;

        /// <inheritdoc/>
        public override long value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
