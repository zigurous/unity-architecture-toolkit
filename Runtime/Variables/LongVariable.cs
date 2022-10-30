using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A long variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Long")]
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
