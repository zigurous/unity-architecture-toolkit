using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// An int variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Int", order = 5)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/IntVariable")]
    public class IntVariable : ScriptableVariable<int>
    {
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private int m_Value;

        /// <inheritdoc/>
        public override int value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
