using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A double variable saved as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Double")]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/DoubleVariable")]
    public class DoubleVariable : ScriptableVariable<double>
    {
        /// <summary>
        /// The value of the variable.
        /// </summary>
        [SerializeField]
        [Tooltip("The value of the variable.")]
        private double m_Value;

        /// <inheritdoc/>
        public override double value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
