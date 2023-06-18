using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A percentage variable saved as a ScriptableObject. Percentages are float
    /// values in the range [0..1].
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Percentage")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/PercentageVariable")]
    public class PercentageVariable : ScriptableVariable<float>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        [Range(0f, 1f)]
        private float m_Value;

        /// <inheritdoc/>
        public override float value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
