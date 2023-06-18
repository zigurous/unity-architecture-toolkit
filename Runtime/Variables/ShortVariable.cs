using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A short variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Short")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ShortVariable")]
    public class ShortVariable : ScriptableVariable<short>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private short m_Value;

        /// <inheritdoc/>
        public override short value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
