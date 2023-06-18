using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A long variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Long")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/LongVariable")]
    public class LongVariable : ScriptableVariable<long>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private long m_Value;

        /// <inheritdoc/>
        public override long value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
