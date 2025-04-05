using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A uint value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/UInt", order = 12)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableUInt")]
    public class ScriptableUInt : ScriptableValue<uint>
    {
        [SerializeField]
        [Delayed]
        private uint m_Value;

        /// <inheritdoc/>
        public override uint value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
