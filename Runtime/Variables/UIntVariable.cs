using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A uint variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/UInt")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/UIntVariable")]
    public class UIntVariable : ScriptableVariable<uint>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private uint m_Value;

        /// <inheritdoc/>
        public override uint value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
