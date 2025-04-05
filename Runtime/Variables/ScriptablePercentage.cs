using UnityEngine;

namespace Zigurous.Architecture
{
    /// <summary>
    /// A percentage value stored as a ScriptableObject. Percentages are float
    /// values in the range [0..1].
    /// </summary>
    [CreateAssetMenu(menuName = "Zigurous/Variables/Percentage", order = 7)]
    [HelpURL("https://docs.zigurous.com/com.zigurous.architecture/api/Zigurous.Architecture/ScriptablePercentage")]
    public class ScriptablePercentage : ScriptableValue<float>
    {
        [SerializeField]
        [Range(0f, 1f)]
        [Delayed]
        private float m_Value;

        /// <inheritdoc/>
        public override float value
        {
            get => m_Value;
            set => m_Value = value;
        }

    }

}
