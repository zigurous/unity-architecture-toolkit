using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A double value stored as a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Double", order = 2)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptableDouble")]
    public class ScriptableDouble : ScriptableValue<double>
    {
        [SerializeField]
        [Delayed]
        private double m_Value;

        /// <inheritdoc/>
        public override double value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
